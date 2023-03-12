using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : Inventory
{
    private Player player = null;

    public Image[] slotsImages = null;
    public Text[] slotsTexts = null;

    private Color itemAffected = new Color(255.0f, 255.0f, 255.0f, 255.0f);
    private Color itemNotAffected = new Color(255.0f, 255.0f, 255.0f, 0.0f);

    private int[] itemIDForSlots = new int[4] { -1, -1, -1, -1 };

    private void Start()
    {
        player = GetComponent<Player>();
        InputManager.instance.inputActions.PlayerInput.Item0.performed += OnUseItem0;
        InputManager.instance.inputActions.PlayerInput.Item1.performed += OnUseItem1;
        InputManager.instance.inputActions.PlayerInput.Item2.performed += OnUseItem2;
        InputManager.instance.inputActions.PlayerInput.Item3.performed += OnUseItem3;
    }

    private void OnUseItem0(InputAction.CallbackContext obj)
    {
        TryUseItem(itemIDForSlots[0], 0);
    }

    private void OnUseItem1(InputAction.CallbackContext obj)
    {
        TryUseItem(itemIDForSlots[1], 1);
    }

    private void OnUseItem2(InputAction.CallbackContext obj)
    {
        TryUseItem(itemIDForSlots[2], 2);
    }

    private void OnUseItem3(InputAction.CallbackContext obj)
    {
        TryUseItem(itemIDForSlots[3], 3);
    }

    private void TryUseItem(int itemID, int slotIndex)
    {
        if(itemID == -1)
        {
            return;
        }

        if (items[itemID].quantity > 0)
        {
            items[itemID].quantity--;
            ItemManager.instance.itemsData.GetGameItemWithID(items[itemID].ID).Use(player);
            UpdateSlot(slotIndex, items[itemID]);
        }
    }

    public override void UpdateSlot(int slotIndex, ItemBackend itemBackend)
    {
        itemIDForSlots[slotIndex] = itemBackend.ID;

        if(itemBackend.ID == -1)
        {
            slotsImages[slotIndex].sprite = null;
            slotsImages[slotIndex].color = itemNotAffected;
            slotsTexts[slotIndex].gameObject.SetActive(false);
            return;
        }

        slotsImages[slotIndex].sprite = ItemManager.instance.itemsData.GetGameItemWithID(itemBackend.ID).sprite;
        slotsImages[slotIndex].color = itemAffected;
        slotsTexts[slotIndex].gameObject.SetActive(true);
        slotsTexts[slotIndex].text = itemBackend.quantity.ToString();
    }
}
