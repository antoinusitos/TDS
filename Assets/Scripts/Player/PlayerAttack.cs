using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Player player = null;

    public Transform attackDetectionTransform = null;

    private float normalAttackSpeed = 0.5f;
    private bool isAttacking = false;
    private float currentAttack = 0.0f;
    private float normalAttackStamina = 15.0f;

    private float bigAttackSpeed = 1.0f;
    private float bigAttackStamina = 30.0f;
    private float currentAttackSpeed = 0.0f;
    private bool normalAttack = true;

    public Animator animator = null;

    private AudioSource audioSource = null;

    private bool isParrying = false;
    public GameObject parryObhect = null;

    private void Start()
    {
        player = GetComponent<Player>();
        InputManager.instance.inputActions.PlayerInput.Attack.performed += OnAttack;
        InputManager.instance.inputActions.PlayerInput.BigAttack.performed += OnBigAttack;
        InputManager.instance.inputActions.PlayerInput.Parry.performed += OnParry;
        InputManager.instance.inputActions.PlayerInput.Parry.canceled += OnStopParry;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawCircle(attackDetectionTransform.position, 1.0f, 32, Color.red);

        if(isAttacking)
        {
            currentAttack += Time.deltaTime;
            if(currentAttack >= currentAttackSpeed)
            {
                currentAttack = 0;
                isAttacking = false;
                player.playerState = PlayerState.GAME;
            }
        }
    }

    private void OnAttack(InputAction.CallbackContext obj)
    {
        TryAttack(true);
    }

    private void OnBigAttack(InputAction.CallbackContext obj)
    {
        TryAttack(false);
    }

    private void TryAttack(bool normalHit = true)
    {
        if (player.playerState != PlayerState.GAME)
        {
            return;
        }

        if (isAttacking)
        {
            return;
        }

        if(player.GetEntityStat().currentStamina < (normalHit ? normalAttackStamina : bigAttackStamina))
        {
            return;
        }

        StopParry();

        player.GetEntityStat().UpdateStaminaStat(-(normalHit ? normalAttackStamina : bigAttackStamina));
        player.UseStamina();

        animator.SetTrigger("Attack");
        normalAttack = normalHit;
        isAttacking = true;
        player.playerState = PlayerState.LOCKED;

        if(normalHit)
        {
            currentAttackSpeed = normalAttackSpeed;
        }
        else
        {
            currentAttackSpeed = bigAttackSpeed;
        }
    }

    public void DetectEnemiesToHit()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackDetectionTransform.position, 1.0f, Vector2.zero);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                AI ai = hits[i].transform.GetComponent<AI>();
                if (ai)
                {
                    ai.TakeDamage(player.GetEntityStat().currentDamage * (normalAttack ? 1.0f : 1.5f));
                }
            }
        }
    }

    public void PlayAttackSound()
    {
        audioSource.Play();
    }

    public void OnParry(InputAction.CallbackContext obj)
    {
        isParrying = true;
        parryObhect.SetActive(true);
    }

    public void OnStopParry(InputAction.CallbackContext obj)
    {
        StopParry();
    }

    public bool GetIsParrying()
    {
        return isParrying;
    }

    public void StopParry()
    {
        isParrying = false;
        parryObhect.SetActive(false);
    }
}
