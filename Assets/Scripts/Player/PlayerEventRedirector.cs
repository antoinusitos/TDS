using UnityEngine;

public class PlayerEventRedirector : MonoBehaviour
{
    public PlayerAttack playerAttack = null;

    public void ExecuteEvent()
    {
        playerAttack.DetectEnemiesToHit();
        playerAttack.PlayAttackSound();
    }
}
