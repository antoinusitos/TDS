using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationDetails
{
    public string notificationText = "";
    public int notificationQuantity = -1;
}

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance = null;

    private bool isClosed = true;

    private List<NotificationDetails> notificationsList = new List<NotificationDetails>();

    public GameObject notificationPanel = null;

    public Text notificationText = null;
    public Text notificationQuantityText = null;

    private void Awake()
    {
        instance = this;
    }

    public void AddNotification(string notification, int quantity = -1)
    {
        notificationsList.Add(new NotificationDetails() { notificationText = notification, notificationQuantity = quantity });
    }

    private void Update()
    {
        if(notificationsList.Count > 0 && isClosed)
        {
            ShowNotification();
        }
    }

    private void ShowNotification()
    {
        Player.instance.playerState = PlayerState.NOTIFICATION;
        isClosed = false;
        notificationText.text = notificationsList[0].notificationText;
        if(notificationsList[0].notificationQuantity != -1)
        {
            notificationQuantityText.text = notificationsList[0].notificationQuantity.ToString();
            notificationQuantityText.gameObject.SetActive(true);
        }
        else
        {
            notificationQuantityText.gameObject.SetActive(false);
        }
        notificationsList.RemoveAt(0);
        notificationPanel.SetActive(true);
    }

    public void CloseNotificationPanel()
    {
        Player.instance.playerState = PlayerState.GAME;
        notificationPanel.SetActive(false);
        isClosed = true;
    }
}
