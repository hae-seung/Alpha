using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SlotHolder : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public GameObject slotPrefab;
    public RectTransform slotParent;
    
    private int usingSlotCnt = 0;
    private int totalSlotCnt = 0;


    public void CreateNewItem(Item newItem)
    {
        if (totalSlotCnt == 0)
            totalSlotCnt = slots.Count;

        if (usingSlotCnt == totalSlotCnt)
        {
            Slot newSlot = Instantiate(slotPrefab, slotParent).GetComponent<Slot>();
            //슬롯 셋업
            newSlot.SetUp(newItem);
            slots.Add(newSlot);
            totalSlotCnt++;
        }
        else
        {
            foreach (Slot slot in slots)
            {
                if (!slot.IsUsing)
                {
                    //슬롯셋업
                    slot.SetUp(newItem);
                    break;
                }
            }
        }
        
        usingSlotCnt++;
    }
}
