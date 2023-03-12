using UnityEngine;

public class EventRedirector : MonoBehaviour
{
    public AIAttack aIAttack = null;

    public void ExecuteEvent()
    {
        aIAttack.DamageTarget();
        aIAttack.PlayAttackSound();
    }
}
