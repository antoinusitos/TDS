using UnityEngine;

public class Shrine : Interactable
{
    public SpriteRenderer spriteRenderer = null;

    private bool isShrineActive = false;

    private AISpawner[] aISpawners = null;

    private bool shrineOpened = false;

    public Transform shrineSpawner = null;

    private void Awake()
    {
        aISpawners = FindObjectsOfType<AISpawner>();
    }

    public override void Execute(PlayerAction playerAction)
    {
        if(!isShrineActive)
        {
            QuickNotificationManager.instance.AddNotification("Shrine is lit");
            isShrineActive = true;
            spriteRenderer.color = Color.yellow;
        }
        else if(!shrineOpened)
        {
            Player.instance.playerState = PlayerState.MENU;
            Player.instance.currentShrine = this;
            Player.instance.ResetPlayer();
            shrineOpened = true;
            UIManager.instance.SetShrineVisibility(true);
            AIManager.instance.WipeAllEnemies();
            AIManager.instance.SpawnAllEnemies();
        }
    }

    public override void Close(PlayerAction playerAction)
    {
        shrineOpened = false;
        Player.instance.playerState = PlayerState.GAME;
        UIManager.instance.SetShrineVisibility(false);
    }
}