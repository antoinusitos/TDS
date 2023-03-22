using UnityEngine;

[System.Serializable]
public class Item
{
    public int ID = -1;
    public string name = "";
    public int quantity = 1;
    public string description = "";
    public Sprite sprite = null;
    public bool isConsummable = true;
    public bool canStayInInventory = true;
    public bool canBeSlotted = true;

    public ItemEffect itemEffect = null;

    public void Use(Entity user)
    {
        if(itemEffect == null)
        {
            return;
        }

        switch(itemEffect.itemEffectType)
        {
            case ItemEffectType.REGEN:
                if(itemEffect.category == 0)
                {
                    user.GetEntityStat().UpdateLifeStat(itemEffect.effectValue);
                    SoundManager.instance.PlaySound("drink");
                }
                break;
            case ItemEffectType.SHAPES:
                Player.instance.GiveShapes((int)itemEffect.effectValue);
                SoundManager.instance.PlaySound("drink");
                break;
        }
    }
}

[System.Serializable]
public class ItemBackend
{
    public int ID = -1;
    public int quantity = 1;
    public int slotAffected = -1;
}

public enum ItemEffectType
{
    NONE,
    REGEN,
    PENALITY,
    SHAPES
}

[System.Serializable]
public class ItemEffect
{
    public ItemEffectType itemEffectType = ItemEffectType.NONE;
    public int category = -1;
    public float effectValue = 0;
}