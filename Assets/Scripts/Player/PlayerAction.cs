using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    public Interactable currentInteractable = null;

    public List<Interactable> allInteractables = new List<Interactable>();

    private Player player = null;

    private void Start()
    {
        player = GetComponent<Player>();
        InputManager.instance.inputActions.PlayerInput.Interact.performed += OnInteract;
        InputManager.instance.inputActions.PlayerInput.Cancel.performed += OnCancel;
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        if (player.playerState == PlayerState.NOTIFICATION)
        {
            NotificationManager.instance.CloseNotificationPanel();
            return;
        }
        else if(player.playerState != PlayerState.GAME)
        {
            return;
        }

        if (currentInteractable)
        {
            currentInteractable.Execute(this);
        }
    }

    private void OnCancel(InputAction.CallbackContext obj)
    {
        if (currentInteractable)
        {
            currentInteractable.Close(this);
        }
    }

    public void AddInteractable(Interactable newInteractable)
    {
        if(allInteractables.Contains(newInteractable))
        {
            return;
        }

        allInteractables.Add(newInteractable);

        if(!currentInteractable)
        {
            currentInteractable = newInteractable;
            currentInteractable.ShowInteraction(true);
        }
    }

    public void RemoveInteractable(Interactable newInteractable)
    {
        if (!allInteractables.Contains(newInteractable))
        {
            return;
        }

        allInteractables.Remove(newInteractable);

        if (currentInteractable == newInteractable)
        {
            currentInteractable.ShowInteraction(false);
            currentInteractable = null;
            if (allInteractables.Count > 0)
            {
                currentInteractable = allInteractables[0];
            }
        }
    }
}
