using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsData", menuName = "ScriptableObjects/ItemsData", order = 1)]
public class ItemsData : ScriptableObject
{
    public List<Item> itemsData = new List<Item>();
    public Item GetGameItemWithID(int anID)
    {
        for (int i = 0; i < itemsData.Count; i++)
        {
            if (itemsData[i].ID == anID)
                return itemsData[i];
        }
        return null;
    }
}
