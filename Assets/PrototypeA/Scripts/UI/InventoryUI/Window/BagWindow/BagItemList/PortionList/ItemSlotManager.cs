using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    public List<Slot> slots;
    public GameObject slotPrefab;
    
    private int slotCount;
    private int usedSlotCount;
    
    [Header("모든 슬롯 총관리자")]
    public InventoryUI inventoryUI;

    [Header("슬롯들의 부모트랜스폼")] 
    public RectTransform slotParent;
    

    public void CreateNewItem(CountableItem newItem, int idx, int stackIdx)
    {
        if (slots == null)
        {
            slots = new List<Slot>();
            slotCount = slots.Count;
            usedSlotCount = 0;
        }
        
        if (usedSlotCount >= slotCount && slotCount>=5)
        {
            Slot newSlot =  Instantiate(slotPrefab, slotParent).GetComponent<Slot>();
            newSlot.SetUp(newItem, idx, stackIdx, this);
            
            slots.Add(newSlot);
            inventoryUI.AddSlot(newSlot);
            usedSlotCount++;
            slotCount++;
        }
        else
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (!slots[i].IsUsing)
                {
                    slots[i].SetUp(newItem, idx, stackIdx, this);
                    inventoryUI.AddSlot(slots[i]);
                    usedSlotCount++;
                    break;
                }
            }
        }
    }

    public void RemoveSlot(int idx, int stackIdx, Slot slot)
    {
        usedSlotCount--;
        inventoryUI.RemoveItem(idx, stackIdx, slot);
    }
    
    public void OpenItemDetailWindow(ItemUI itemUI)
    {
        inventoryUI.OpenItemDetailWindow(itemUI);
    }
}
