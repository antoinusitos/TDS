using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class AI : Entity
{
    public Slider lifeSlider = null;

    public ItemDrop itemDropPrefab = null;

    protected Player target = null;

    protected NavMeshAgent navMeshAgent = null;

    public float stoppingDistance = 3.0f;

    public Transform aiSprite = null;

    public bool canMove = true;

    public int shapesGiven = 0;

    public GameObject targetFeedback = null;

    public UnityEvent eventOnDeath = null;

    protected Vector3 startPosition = Vector3.zero;

    protected bool returningToPosition = false;

    protected virtual void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        startPosition = transform.position;
        navMeshAgent.enabled = true;
    }

    public override void TakeDamage(float amount)
    {
        SoundManager.instance.PlaySound("hit");
        entityStat.UpdateLifeStat(-amount);
        lifeSlider.value = entityStat.currentLife / entityStat.maxLife;
        if (entityStat.currentLife <= 0)
        {
            Inventory inventory = GetComponent<Inventory>();
            if(inventory)
            {
                foreach(KeyValuePair<int, ItemBackend> itemBackend in inventory.items)
                {
                    ItemDrop drop = Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
                    drop.itemBackend.ID = itemBackend.Value.ID;
                    drop.itemBackend.quantity = itemBackend.Value.quantity;
                }
            }

            eventOnDeath.Invoke();
            Player.instance.GiveShapes(shapesGiven);
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        if(returningToPosition)
        {
            HandleRotation((startPosition - transform.position).normalized);
            if (Vector3.Distance(startPosition, transform.position) > stoppingDistance)
            {
                navMeshAgent.SetDestination(startPosition);
            }
            else
            {
                returningToPosition = false;
            }
            return;
        }

        if (!target)
        {
            return;
        }

        if(!canMove)
        {
            return;
        }

        HandleRotation((target.transform.position - transform.position).normalized);

        if (Vector3.Distance(target.transform.position, transform.position) > stoppingDistance)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);
            WantToAttack();
        }
    }

    protected void HandleRotation(Vector3 vector)
    {
        float Angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        aiSprite.localRotation = Quaternion.Euler(0, 0, Angle - 90);
    }

    protected virtual void WantToAttack()
    {

    }

    public void SetCanMove(bool newState)
    {
        canMove = newState;
        if(!canMove)
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player && player.playerState != PlayerState.DEAD)
        {
            navMeshAgent.velocity = Vector3.zero;
            target = player;
            returningToPosition = false;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            LostTarget();
        }
    }

    public void LostTarget()
    {
        target = null;
        navMeshAgent.velocity = Vector3.zero;
        if (navMeshAgent && navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.SetDestination(startPosition);
            returningToPosition = true;
        }
    }
}
