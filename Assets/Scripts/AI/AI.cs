using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI : Entity
{
    public Slider lifeSlider = null;

    public ItemDrop itemDropPrefab = null;

    private Player target = null;

    private NavMeshAgent navMeshAgent = null;

    public float stoppingDistance = 3.0f;

    public Transform aiSprite = null;

    private AIAttack aIAttack = null;

    public bool canMove = true;

    public float XPGiven = 0.0f;

    private void Start()
    {
        aIAttack = GetComponent<AIAttack>();
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

            Destroy(gameObject);
        }
    }

    private void Update()
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
            aIAttack.WantToAttack();
        }
    }

    public void SetCanMove(bool newState)
    {
        canMove = newState;
        if(!canMove)
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player)
        {
            target = player;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
