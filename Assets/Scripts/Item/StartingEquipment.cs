using System.Collections.Generic;
using UnityEngine;

public class StartingEquipment : MonoBehaviour
{
    public List<ItemBackend> startingEquipment = new List<ItemBackend>();

    private Inventory inventory = null;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        if(inventory)
        {
            for(int i = 0; i < startingEquipment.Count; i++)
            {
                inventory.AddItem(startingEquipment[i].ID, startingEquipment[i].quantity, startingEquipment[i].slotAffected);
            }
        }
    }

    public void RefillIfMissing()
    {
        if (inventory)
        {
            for (int i = 0; i < startingEquipment.Count; i++)
            {
                ItemBackend item = inventory.GetItem(startingEquipment[i].ID);
                if (item == null)
                {
                    inventory.AddItem(startingEquipment[i].ID, startingEquipment[i].quantity, startingEquipment[i].slotAffected);
                }
                else
                {
                    if(item.quantity < startingEquipment[i].quantity)
                    {
                        inventory.AddItem(startingEquipment[i].ID, startingEquipment[i].quantity - item.quantity, startingEquipment[i].slotAffected);
                    }
                }
            }
        }
    }
}
