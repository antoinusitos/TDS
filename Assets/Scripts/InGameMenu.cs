using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Text lifeText = null;
    public Text staminaText = null;
    public Text xpText = null;

    public Text inventoryTextPrefab = null;
    public Transform inventoryPanel = null;

    public void Start()
    {
        InputManager.instance.inputActions.PlayerInput.Cancel.performed += OnCancel;
    }

    public void OnEnable()
    {
        NotificationManager.instance.CloseNotificationPanel();

        EntityStat entityStat = Player.instance.GetEntityStat();
        lifeText.text = $"Life : {entityStat.currentLife} / {entityStat.maxLife}";
        staminaText.text = $"Stamina : {entityStat.currentStamina} / {entityStat.maxStamina}";
        xpText.text = $"XP : {entityStat.currentXP}";

        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            Destroy(inventoryPanel.GetChild(i).gameObject);
        }

        Inventory inventory = Player.instance.GetComponent<Inventory>();
        foreach (KeyValuePair<int, ItemBackend> itemBackend in inventory.items)
        {
            Item item = ItemManager.instance.itemsData.GetGameItemWithID(itemBackend.Key);
            Instantiate(inventoryTextPrefab, inventoryPanel).text = $"{item.name} \t x{itemBackend.Value.quantity}";
        }
    }

    private void OnCancel(InputAction.CallbackContext obj)
    {
        if (!enabled)
        {
            return;
        }

        gameObject.SetActive(false);
        Player.instance.playerState = PlayerState.GAME;
    }
}
