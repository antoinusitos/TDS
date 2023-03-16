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

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    public void TakeDamage(float amount)
    {
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
            Player.instance.GetEntityStat().UpdateShapesStat(shapesGiven);
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        if (!target)
        {
            return;
        }

        if(!canMove)
        {
            return;
        }

        Vector3 NewVector = target.transform.position - transform.position;
        NewVector.Normalize();
        float Angle = Mathf.Atan2(NewVector.y, NewVector.x) * Mathf.Rad2Deg;

        aiSprite.localRotation = Quaternion.Euler(0, 0, Angle - 90);

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
        if(player)
        {
            target = player;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            target = null;
            if(navMeshAgent && navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
