using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;
    public GameObject Rock;
    public GameObject Equip;
    public GameObject selectedItemImage;


    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    //public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject backButton;
    //public GameObject dropButton;

    private int curEquipIndex;

    private PlayerController controller; 
    private PlayerInfo playerInfo;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    public static Inventory instance;
    void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerController>();
        playerInfo = GetComponent<PlayerInfo>();
    }
    private void Start()
    {
        slots = new ItemSlot[uiSlots.Length];
        curEquipIndex = 9999;

        for (int i = 0; i < slots.Length; i++)
        {
            if(i==0)
            {
                slots[i] = new ItemSlot();
                slots[0].item = Rock.GetComponent<ItemObject>().item;
                uiSlots[i].icon.sprite = Rock.GetComponent<ItemObject>().item.icon;
                uiSlots[i].index = i;
            }
            else
            {
                slots[i] = new ItemSlot();
                uiSlots[i].index = i;
                uiSlots[i].Clear();
            }
            
        }     

    }

    public void AddItem(ItemData item)
    {
        if (item.canStack)//아이템이 쌓일 수 있는지 확인
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if (slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && slots[i].quantity < item.maxStackAmount)
                return slots[i];
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
                return slots[i];
        }

        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].item == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        bool equipOn = false;
        Time.timeScale = 0.0f;
        Equip.SetActive(true);
        selectedItemImage.GetComponent<Image>().sprite = uiSlots[index].icon.sprite;

        if(selectedItemIndex == curEquipIndex)
        {
            equipOn = true;
        }

        switch(selectedItem.item.type)
        {
            case ItemType.Equipable:
                switch(equipOn)
                {
                    case true:
                        equipButton.SetActive(false);
                        unEquipButton.SetActive(true);
                        break;
                    case false:
                        equipButton.SetActive(true);
                        unEquipButton.SetActive(false);
                        break;
                }
                break;
            case ItemType.Consumable:
                equipButton.SetActive(false);
                unEquipButton.SetActive(false);
                break;
            case ItemType.Resource:
                break;
            default:
                break;
        }

    }

    public void OnUseButton()
    {
        if (selectedItem.item.type == ItemType.Consumable)
        {
            for (int i = 0; i < selectedItem.item.consumables.Length; i++)
            {
                switch (selectedItem.item.consumables[i].type)
                {
                    case ConsumableType.Health:
                        playerInfo.Heal(selectedItem.item.consumables[i].value); 
                        break;
                    case ConsumableType.Attack:
                        playerInfo.ItemAttackStat(selectedItem.item.consumables[i].value);
                        break;
                    case ConsumableType.Defense:
                        playerInfo.ItemDefenseStat(selectedItem.item.consumables[i].value);
                        break;
                    case ConsumableType.Critical:
                        playerInfo.ItemCriticalStat(selectedItem.item.consumables[i].value);
                        break;
                }
            }
        }
        RemoveSelectedItem();
    }

    public void OnEquipButton()
    {

        try
        {
           if(uiSlots[curEquipIndex].equipped)
            {
                UnEquip(curEquipIndex);
            }
        }catch
        {

        }
  
        uiSlots[selectedItemIndex].equipped = true;
        curEquipIndex = selectedItemIndex;
        EquipManager.instance.EquipNew(selectedItem.item);

        uiSlots[selectedItemIndex].GetComponentInChildren<Text>().text = "E";
        uiSlots[selectedItemIndex].equipped = true;

        UpdateUI();

        SelectItem(selectedItemIndex);

        Time.timeScale = 1f;
        Equip.SetActive(false);
    }

    void UnEquip(int index)
    {
        uiSlots[index].equipped = false;
        uiSlots[index].GetComponentInChildren<Text>().text = "";
        EquipManager.instance.UnEquip();
        UpdateUI();

        if (selectedItemIndex == index)
            SelectItem(index);
    }

    public void OnUnEquipButton()
    {
        UnEquip(selectedItemIndex);
        Time.timeScale = 1f;
        Equip.SetActive(false);
    }

    public void OnDropButton()
    {
        RemoveSelectedItem();
    }

    public void OnBackButton()
    {
        Time.timeScale = 1f;
        Equip.SetActive(false);
    }

    private void RemoveSelectedItem()
    {
        selectedItem.quantity--;

        if (selectedItem.quantity <= 0)
        {
            if (uiSlots[selectedItemIndex].equipped)
            {
                UnEquip(selectedItemIndex);
            }

            selectedItem.item = null;
        }

        UpdateUI();
    }

    public void RemoveItem(ItemData item)
    {

    }

    public bool HasItems(ItemData item, int quantity)
    {
        return false;
    }
}