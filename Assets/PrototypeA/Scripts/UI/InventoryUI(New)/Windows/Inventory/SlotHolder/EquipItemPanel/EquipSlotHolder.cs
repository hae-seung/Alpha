using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipSlotHolder : MonoBehaviour
{
    public List<EquipSlot> slots;
        
    
    public void WearItem(Item item) 
    {
        if (item is IEquippable eitem)
        {
            foreach (var slot in slots)
            {
                if (slot.GetSlotType().Equals(eitem.GetItemType()))
                {
                    slot.SetUpUI(item);
                    break;
                }
            }
        }
        else
        {
            Debug.Log("아이템을 장착할 수 없습니다");
            return;
        }
    }
}
