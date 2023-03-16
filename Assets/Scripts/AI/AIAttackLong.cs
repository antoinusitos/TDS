using UnityEngine;

public class AIAttackLong : MonoBehaviour
{
    public Transform attackDetectionTransform = null;

    private bool canAttack = true;

    private readonly float attackRate = 1.5f;
    private float currentRate = 0;

    private EntityStat entityStat = null;

    public Animator attackAnimator = null;

    private AI aI = null;

    private AudioSource audioSource = null;

    public float attackSize = 1.0f;

    public Arrow arrowPrefab = null;

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

    public void WantToAttack(Transform newTarget)
    {
        if (canAttack)
        {
            aI.SetCanMove(false);
            canAttack = false;
            ShootArrow(newTarget);
        }
    }

    public void ShootArrow(Transform newTarget)
    {
        audioSource.Play();
        Arrow arrow = Instantiate(arrowPrefab, attackDetectionTransform.position, Quaternion.identity);
        arrow.entityStatLinked = entityStat;
        arrow.direction = (newTarget.position - transform.position).normalized;
        arrow.sender.Add(transform);
        arrow.sender.Add(transform.GetChild(2));
    }

    public void PlayAttackSound()
    {
        audioSource.Play();
    }
}
