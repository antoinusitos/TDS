using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, ItemBackend> items = new Dictionary<int, ItemBackend>();

    public void AddItem(int ID, int quantity, int slot = -1)
    {
        if (items.ContainsKey(ID))
        {
            items[ID].quantity += quantity;
            if (items[ID].slotAffected != -1)
            {
                UpdateSlot(0, items[ID]);
            }
            return;
        }

        ItemBackend itemBackend = new ItemBackend() { ID = ID, quantity = quantity, slotAffected = slot };
        items.Add(ID, itemBackend);
        if (slot != -1)
        {
            UpdateSlot(slot, itemBackend);
        }
    }

    public ItemBackend GetItem(int ID)
    {
        if(items.ContainsKey(ID))
        {
            return items[ID];
        }
        return null;
    }

    public virtual void UpdateSlot(int slotIndex, ItemBackend itemBackend)
    {

    }
}
