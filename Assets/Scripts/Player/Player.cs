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

    public GameObject interactionText = null;

    public Shrine currentShrine = null;

    private StartingEquipment startingEquipment = null;

    private Vector3 startingPoint = Vector3.zero;

    public GameObject menuCanvas = null;

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
        if(entityStat.lifeValueDirty)
        {
            lifeSlider.value = entityStat.currentLife / entityStat.maxLife;
        }
        if (entityStat.staminaValueDirty)
        {
            staminaSlider.value = entityStat.currentStamina / entityStat.maxStamina;
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
        if (startingEquipment)
        {
            startingEquipment.RefillIfMissing();
        }
    }

    public void GiveXP(float amount)
    {
        entityStat.UpdateXPStat(amount);
    }
}
