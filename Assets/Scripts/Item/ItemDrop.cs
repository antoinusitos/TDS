public class ItemDrop : Interactable
{
    public ItemBackend itemBackend = null;

    public override void Execute(PlayerAction playerAction)
    {
        playerAction.GetComponent<PlayerInventory>().AddItem(itemBackend.ID, itemBackend.quantity);
        NotificationManager.instance.AddNotification(ItemManager.instance.itemsData.GetGameItemWithID(itemBackend.ID).name, itemBackend.quantity);
        SoundManager.instance.PlaySound("pickup");
        Destroy(gameObject);
    }
}
