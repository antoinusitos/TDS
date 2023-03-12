using UnityEngine;

public class DoorSide : MonoBehaviour
{
    public bool isBlocked = false;
    public bool isLocked = false;

    public Door linkedDoor = null;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        linkedDoor.SetDoorSide(this);
        pa.AddInteractable(linkedDoor);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        pa.RemoveInteractable(linkedDoor);
    }
}
