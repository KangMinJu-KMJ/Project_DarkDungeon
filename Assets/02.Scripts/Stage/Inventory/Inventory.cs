using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory_Base;//인벤토리 열고 닫을 때 쓰임
    public static bool inventoryOpen = false;//인벤토리 열고 닫는 bool 변수

    public Slots[] slots;
    [SerializeField]
    private Transform slotParent; // Grid Setting

    void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slots>();
    }

    void Update()
    {
        InventoryOption();
        
    }

    void InventoryOption()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryOpen = !inventoryOpen;

            if (inventoryOpen)
            {
                InventoryOpen();
            }
            else
            {
                InventoryClose();
            }
        }
    }

    void InventoryOpen()
    {
        Time.timeScale = 0;
        inventory_Base.SetActive(true);
    }

    void InventoryClose()
    {
        Time.timeScale = 1;
        inventory_Base.SetActive(false);
    }

    public void AcquireItem(Items _items, int _count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items.itemName != "")//슬롯에 아이템이 있을때
            {
                if (slots[i].items.itemName == _items.itemName)//슬롯에 있는 아이템이름과 같을때
                {
                    slots[i].SetSlotCount(_count);
                    return;
                }
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items.itemName == "")//슬롯에 아이템이 없을때
            {
                slots[i].AddItem(_items, _count);
                return;
            }
        }
    }
}
