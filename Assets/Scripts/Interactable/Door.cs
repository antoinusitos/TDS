using System.Collections;
using UnityEngine;

public class Door : Interactable
{
    private bool opened = false;

    private DoorSide usedDoorSide = null;

    public Vector3 openMovementSize = Vector3.zero;

    public float openSpeed = 2.0f;

    private Vector3 startPosition = Vector3.zero;

	private AudioSource audioSource = null;

    public int keyID = -1;

    public AudioSource lockedAudioSource = null;

    private void Awake()
    {
        overrideTriggerEnter = true;
		audioSource = GetComponent<AudioSource>();
    }

    public void SetDoorSide(DoorSide newDoorSide)
    {
        usedDoorSide = newDoorSide;
    }

    public override void ShowInteraction(bool newState)
    {
        if(!opened)
        {
            Player.instance.ShowInteraction(newState);
        }
    }

    public override void Execute(PlayerAction playerAction)
    {
        if (opened)
        {
            return;
        }

        if(usedDoorSide.isBlocked)
        {
            NotificationManager.instance.AddNotification("Door open from the other side");
        }
        else if (usedDoorSide.isLocked)
        {
            PlayerInventory pi = playerAction.GetComponent<PlayerInventory>();
            if (pi)
            {
                if(pi.items.ContainsKey(keyID))
                {
                    NotificationManager.instance.AddNotification("Used " + ItemManager.instance.itemsData.GetGameItemWithID(keyID).name);
                    NotificationManager.instance.PlayUnlockSound();
                    usedDoorSide.isLocked = false;
                    return;
                }
            }
            lockedAudioSource.Play();
            NotificationManager.instance.AddNotification("Door is locked");
        }
        else
        {
            ShowInteraction(false);
            opened = true;
            StartCoroutine("OpenDoor");
        }
    }

    public void ForceCloseDoor()
    {
        opened = false;
        StartCoroutine("CloseDoor");
    }

    private IEnumerator CloseDoor()
    {
        audioSource.Play();
        Transform localTransform = transform;
        startPosition = localTransform.position;
        float timer = 0;
        while (timer < 1)
        {
            localTransform.position = Vector3.Lerp(startPosition, startPosition - openMovementSize, timer);
            timer += Time.deltaTime * openSpeed;
            yield return null;
        }
    }

    private IEnumerator OpenDoor()
    {
		audioSource.Play();
        Transform localTransform = transform;
        startPosition = localTransform.position;
        float timer = 0;
        while(timer < 1)
        {
            localTransform.position = Vector3.Lerp(startPosition, startPosition + openMovementSize, timer);
            timer += Time.deltaTime * openSpeed;
            yield return null;
        }
    }
}
