using UnityEngine;

public class AILong : AI
{
    private AIAttackLong aIAttack = null;

    protected override void Start()
    {
        base.Start();
        aIAttack = GetComponent<AIAttackLong>();
    }
    protected override void Update()
    {
        if (!target)
        {
            return;
        }

        Vector3 NewVector = target.transform.position - transform.position;
        NewVector.Normalize();
        float Angle = Mathf.Atan2(NewVector.y, NewVector.x) * Mathf.Rad2Deg;

        aiSprite.localRotation = Quaternion.Euler(0, 0, Angle - 90);

        aIAttack.WantToAttack(target.transform);
    }
}
