using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SlotHolder : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public GameObject slotPrefab;
    public RectTransform rect;
    
    private int usingSlotCnt = 0;
    private int totalSlotCnt = 0;


    public void CreateNewItem(Item newItem)
    {
        if (totalSlotCnt == 0)
            totalSlotCnt = slots.Count;

        if (usingSlotCnt == totalSlotCnt)
        {
            Slot newSlot = Instantiate(slotPrefab, rect).GetComponent<Slot>();
            newSlot.SetUp(newItem, this);
            slots.Add(newSlot);
            totalSlotCnt++;
        }
        else
        {
            foreach (Slot slot in slots)
            {
                if (!slot.IsUsing)
                {
                    slot.SetUp(newItem, this);
                    break;
                }
            }
        }
        
        usingSlotCnt++;
    }

    public void RemoveItem(Item item)
    {
        foreach (var slot in slots)
        {
            if (slot.IsUsing && slot.GetItem() == item)
                slot.EndSlotUsage();
        }
    }
    
    
    
    public void FreeSlot()
    {
        usingSlotCnt--;
    }
}
