using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickNotificationManager : MonoBehaviour
{
    public static QuickNotificationManager instance = null;

    private bool isClosed = true;

    private List<string> notificationsList = new List<string>();

    public Text notificationText = null;

    public float animationSpeed = 2.0f;

    private WaitForSeconds showingTiming = null;

    private void Awake()
    {
        instance = this;
        showingTiming = new WaitForSeconds(1);
    }

    public void AddNotification(string notification)
    {
        notificationsList.Add(notification);
    }

    private void Update()
    {
        if (notificationsList.Count > 0 && isClosed)
        {
            ShowNotification();
        }
    }

    private void ShowNotification()
    {
        isClosed = false;
        notificationText.text = notificationsList[0];
        notificationsList.RemoveAt(0);
        StartCoroutine(NotificationAnimation());
    }

    private IEnumerator NotificationAnimation()
    {
        float timer = 0;
        Color white = Color.white;
        white.a = 0;
        while (timer < 1)
        {
            white.a = Mathf.Lerp(0, 1.0f, timer);
            notificationText.color = white;
            timer += Time.deltaTime * animationSpeed;
            yield return null;
        }
        timer = 1;
        yield return showingTiming;
        while (timer > 0)
        {
            white.a = Mathf.Lerp(0, 1.0f, timer);
            notificationText.color = white;
            timer -= Time.deltaTime * animationSpeed;
            yield return null;
        }
        white.a = 0;
        notificationText.color = white;
        isClosed = true;
    }
}
