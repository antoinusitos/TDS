public class LostShapes : Interactable
{
    public int shapes = 0;

    public override void Execute(PlayerAction playerAction)
    {
        Player.instance.GiveShapes(shapes);
        SoundManager.instance.PlaySound("pickup");
        QuickNotificationManager.instance.AddNotification("Lost Shapes Retrieved");
        SoundManager.instance.PlaySound("location");
        Destroy(gameObject);
    }
}
