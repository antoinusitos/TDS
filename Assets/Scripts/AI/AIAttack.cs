using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public Transform attackDetectionTransform = null;

    private bool canAttack = true;

    private float attackRate = 1.5f;
    private float currentRate = 0;

    private EntityStat entityStat = null;

    public Animator attackAnimator = null;

    private AI aI = null;

    private AudioSource audioSource = null;

    public float attackSize = 1.0f;

    private void Start()
    {
        aI = GetComponent<AI>();
        entityStat = aI.GetEntityStat();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawCircle(attackDetectionTransform.position, attackSize, 32, Color.red);

        if (!canAttack)
        {
            currentRate += Time.deltaTime;
            if (currentRate >= attackRate)
            {
                currentRate = 0;
                canAttack = true;
                aI.SetCanMove(true);
            }
        }
    }

    public void WantToAttack()
    {
        if (canAttack)
        {
            aI.SetCanMove(false);
            canAttack = false;
            attackAnimator.SetTrigger("Attack");
        }
    }

    public void DamageTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackDetectionTransform.position, attackSize, Vector2.zero);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                Player player = hits[i].transform.GetComponent<Player>();
                if (player)
                {
                    player.TakeDamage(entityStat.currentDamage);
                    if(player.GetEntityStat().currentLife <= 0)
                    {
                        aI.LostTarget();
                    }
                }
            }
        }
    }

    public void PlayAttackSound()
    {
        audioSource.Play();
    }
}
