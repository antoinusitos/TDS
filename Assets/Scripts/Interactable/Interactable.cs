using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool overrideTriggerEnter = false;

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

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(overrideTriggerEnter)
        {
            return;
        }

        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        pa.AddInteractable(this);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (overrideTriggerEnter)
        {
            return;
        }

        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        pa.RemoveInteractable(this);
    }
}
