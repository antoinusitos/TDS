using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;

    public ItemsData itemsData = null;

    private void Awake()
    {
        instance = this;
    }
}