using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum PlayerState
{
    GAME,
    MENU,
    NOTIFICATION,
    LOCKED,
    DEAD,
}

public class Player : Entity
{
    public static Player instance = null;

    public PlayerState playerState = PlayerState.GAME;

    public Slider lifeSlider = null;
    public Slider staminaSlider = null;

    public Text shapesText = null;

    public GameObject interactionText = null;

    public Shrine currentShrine = null;

    private StartingEquipment startingEquipment = null;

    private Vector3 startingPoint = Vector3.zero;

    public GameObject menuCanvas = null;

    private readonly float staminaRecoverDelay = 2.0f;
    private float currentStaminaRecoverDelay = 0f;
    private readonly float staminaRecoverSpeed = 20.0f;

    private PlayerAttack playerAttack = null;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        startingEquipment = GetComponent<StartingEquipment>();
        startingPoint = transform.position;
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Start()
    {
        InputManager.instance.inputActions.PlayerInput.Menu.performed += OnMenu;
    }

    private void Update()
    {
        if(menuCanvas.activeSelf)
        {
            return;
        }

        if(currentStaminaRecoverDelay < staminaRecoverDelay)
        {
            currentStaminaRecoverDelay += Time.deltaTime * (playerAttack.GetIsParrying() ? 0.5f : 1.0f);
        }
        else if(entityStat.currentStamina < entityStat.maxStamina)
        {
            entityStat.UpdateStaminaStat(Time.deltaTime * staminaRecoverSpeed * (playerAttack.GetIsParrying() ? 0.5f : 1.0f));
        }

        if (entityStat.lifeValueDirty)
        {
            lifeSlider.value = entityStat.currentLife / entityStat.maxLife;
        }
        if (entityStat.staminaValueDirty)
        {
            staminaSlider.value = entityStat.currentStamina / entityStat.maxStamina;
        }
        if (entityStat.shapesValueDirty)
        {
            shapesText.text = entityStat.currentShapes.ToString();
        }
    }

    private void OnMenu(InputAction.CallbackContext obj)
    {
        if (playerState == PlayerState.MENU || playerState == PlayerState.NOTIFICATION)
            return;

        playerState = PlayerState.MENU;
        menuCanvas.SetActive(true);
    }

    public override void TakeDamage(float value)
    {
        if(playerState == PlayerState.DEAD)
        {
            return;
        }

        if(playerAttack.GetIsParrying())
        {
            float staminaBefore = entityStat.currentStamina;
            entityStat.UpdateStaminaStat(-value);
            UseStamina();

            if(entityStat.currentStamina <= 0)
            {
                playerAttack.StopParry();
            }

            if (staminaBefore >= value)
            {
                SoundManager.instance.PlaySound("parry");
                return;
            }
        }

        SoundManager.instance.PlaySound("hit");

        entityStat.UpdateLifeStat(-value);
        if(entityStat.currentLife <= 0)
        {
            SoundManager.instance.PlaySound("death");
            playerState = PlayerState.DEAD;
            UIManager.instance.ShowDeathScreen();
        }
    }

    public virtual void ShowInteraction(bool newState)
    {
        interactionText.SetActive(newState);
    }

    public void ResetPlayer()
    {
        entityStat.UpdateLifeStat(entityStat.maxLife);
        entityStat.UpdateStaminaStat(entityStat.maxStamina);
        entityStat.UpdateShapesStat(-entityStat.currentShapes);
        playerState = PlayerState.GAME;
        if (startingEquipment)
        {
            startingEquipment.RefillIfMissing();
        }
    }

    public void GiveShapes(int amount)
    {
        entityStat.UpdateShapesStat(amount);
    }

    public void UseStamina()
    {
        currentStaminaRecoverDelay = 0;
    }

    public void HandlePlayerDeath()
    {
        if (currentShrine != null)
        {
            transform.position = currentShrine.shrineSpawner.position;
        }
        else
        {
            transform.position = startingPoint;
        }
        CameraMovement.instance.SetCameraOnPlayer();
        AIManager.instance.WipeAllEnemies();
        AIManager.instance.SpawnAllEnemies();
        ResetPlayer();
    }
}
