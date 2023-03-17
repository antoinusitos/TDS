using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static LevelScript instance = null;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ShowLocation();
    }

    public void ShowLocation()
    {
        SoundManager.instance.PlaySound("location");
        QuickNotificationManager.instance.AddNotification("CASTLE JAIL");
    }
}
