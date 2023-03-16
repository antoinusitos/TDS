using UnityEngine.AI;

public class AIShort : AI
{
    private AIAttack aIAttack = null;

    private void Start()
    {
        aIAttack = GetComponent<AIAttack>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    protected override void WantToAttack()
    {
        aIAttack.WantToAttack();
    }
}
