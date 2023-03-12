using UnityEngine;

public class LevelScript : MonoBehaviour
{
    private void Start()
    {
        QuickNotificationManager.instance.AddNotification("CASTLE JAIL");
    }
}
