using UnityEngine;

public class DoorModifier : MonoBehaviour
{
    public DoorSide doorToModify = null;

    public bool newLockState = false;
    public bool newBlockState = false;

    public bool mustClose = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player)
        {
            doorToModify.isLocked = newLockState;
            doorToModify.isBlocked = newBlockState;

            if(mustClose)
            {
                doorToModify.linkedDoor.ForceCloseDoor();
            }

            Destroy(gameObject);
        }
    }
}
