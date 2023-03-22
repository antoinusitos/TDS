using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Text lifeText = null;
    public Text staminaText = null;
    public Text xpText = null;

    public Button inventoryTextPrefab = null;
    public Transform inventoryPanel = null;

    public Text inventoryNameText = null;
    public Text inventoryDescriptionText = null;

    private int indexItem = 0;

    private PlayerInventory playerInventory = null;

    private List<InventoryButtonAssociation> buttons = new List<InventoryButtonAssociation>();

    private int lastButtonsLength = 0;

    public Button useButton = null;

    private Color unselectColor = new Color(0, 0, 0, 63.0f / 255.0f);

    public void Start()
    {
        InputManager.instance.inputActions.PlayerInput.Cancel.performed += OnCancel;
    }

    public void OnEnable()
    {
        if (!playerInventory)
        {
            playerInventory = Player.instance.GetComponent<PlayerInventory>();
        }

        RefreshInventory();
    }

    private void RefreshInventory(bool resetPos = true)
    {
        if(resetPos || lastButtonsLength != playerInventory.items.Count)
        {
            indexItem = 0;
        }

        buttons.Clear();

        NotificationManager.instance.CloseNotificationPanel();

        EntityStat entityStat = Player.instance.GetEntityStat();
        lifeText.text = $"Life : {entityStat.currentLife} / {entityStat.maxLife}";
        staminaText.text = $"Stamina : {entityStat.currentStamina} / {entityStat.maxStamina}";
        xpText.text = $"Shapes : {entityStat.currentShapes}";

        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            Destroy(inventoryPanel.GetChild(i).gameObject);
        }

        int index = 0;
        foreach (KeyValuePair<int, ItemBackend> itemBackend in playerInventory.items)
        {
            Item item = ItemManager.instance.itemsData.GetGameItemWithID(itemBackend.Key);
            Button button = Instantiate(inventoryTextPrefab, inventoryPanel);
            button.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
            InventoryButtonAssociation inventoryButtonAssociation = button.GetComponent<InventoryButtonAssociation>();
            inventoryButtonAssociation.itemAssociated = item;
            buttons.Add(inventoryButtonAssociation);
            int localIndex = index;
            if (index == 0 && resetPos)
            {
                SelectItem(localIndex);
            }
            button.onClick.AddListener(delegate
            {
                SelectItem(localIndex);
            });
            index++;
        }
        lastButtonsLength = playerInventory.items.Count;
        if (!resetPos)
        {
            SelectItem(indexItem);
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

    private void SelectItem(int newIndex)
    {
        buttons[indexItem].GetComponent<Image>().color = unselectColor;

        indexItem = newIndex;
        int ID = buttons[indexItem].itemAssociated.ID;
        inventoryNameText.text = $"{buttons[newIndex].itemAssociated.name} \t x{playerInventory.items[ID].quantity}";
        inventoryDescriptionText.text = buttons[newIndex].itemAssociated.description;
        buttons[newIndex].GetComponent<Image>().color = Color.red;
        if (buttons[newIndex].itemAssociated.isConsummable)
        {
            useButton.interactable = true;
        }
        else
        {
            useButton.interactable = false;
        }
    }

    public void UseItem()
    {
        int ID = buttons[indexItem].itemAssociated.ID;
        playerInventory.TryUseItem(ID, playerInventory.items[ID].slotAffected);
        RefreshInventory(false);
    }

    public void MoveRight()
    {
        
    }
}
