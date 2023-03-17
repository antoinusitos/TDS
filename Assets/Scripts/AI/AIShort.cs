public class AIShort : AI
{
    private AIAttack aIAttack = null;

    protected override void Start()
    {
        base.Start();
        aIAttack = GetComponent<AIAttack>();
    }

    protected override void WantToAttack()
    {
        aIAttack.WantToAttack();
    }
}
