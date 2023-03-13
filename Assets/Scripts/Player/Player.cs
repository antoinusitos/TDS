using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum PlayerState
{
    GAME,
    MENU,
    NOTIFICATION,
    LOCKED
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

    private readonly float staminaRecoverDelay = 1.0f;
    private float currentStaminaRecoverDelay = 0f;
    private readonly float staminaRecoverSpeed = 20.0f;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        startingEquipment = GetComponent<StartingEquipment>();
        startingPoint = transform.position;
    }

    private void Start()
    {
        InputManager.instance.inputActions.PlayerInput.Menu.performed += OnMenu;
    }

    private void Update()
    {
        if(currentStaminaRecoverDelay < staminaRecoverDelay)
        {
            currentStaminaRecoverDelay += Time.deltaTime;
        }
        else if(entityStat.currentStamina < entityStat.maxStamina)
        {
            entityStat.UpdateStaminaStat(Time.deltaTime * staminaRecoverSpeed);
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

    public void TakeDamage(float value)
    {
        entityStat.UpdateLifeStat(-value);
        if(entityStat.currentLife <= 0)
        {
            if(currentShrine != null)
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

    public virtual void ShowInteraction(bool newState)
    {
        interactionText.SetActive(newState);
    }

    public void ResetPlayer()
    {
        entityStat.UpdateLifeStat(entityStat.maxLife);
        entityStat.UpdateStaminaStat(entityStat.maxStamina);
        entityStat.UpdateShapesStat(-entityStat.currentShapes);
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
}
