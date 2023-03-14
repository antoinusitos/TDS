using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void ShowInteraction(bool newState)
    {
        Player.instance.ShowInteraction(newState);
    }

    public virtual void Execute(PlayerAction playerAction)
    {

    }

    public virtual void Close(PlayerAction playerAction)
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        pa.AddInteractable(this);
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        pa.RemoveInteractable(this);
    }
}
