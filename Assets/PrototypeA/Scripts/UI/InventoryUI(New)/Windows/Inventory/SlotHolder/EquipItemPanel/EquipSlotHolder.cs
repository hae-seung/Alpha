using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipSlotHolder : MonoBehaviour
{
    public List<EquipSlot> slots;
    
    public void WearItem(Item item, string weaponSlot = null) 
    {
        if (item is IEquippable eitem && weaponSlot == null)
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
        else if(weaponSlot != null)
        {
            foreach (var slot in slots)
            {
                if (slot.gameObject.name.Equals(weaponSlot))
                {
                    slot.SetUpUI(item);
                    break;
                }
            }
        }
    }

    public void UnWearItem(Item item, string weaponSlot = null)
    {
        if (item is IEquippable eitem && weaponSlot == null)
        {
            foreach (var slot in slots)
            {
                if (slot.GetSlotType().Equals(eitem.GetItemType()) && slot.IsUsing)
                {
                    slot.EndSlotUsage();
                    break;
                }
            }
        }
        else if(weaponSlot != null)
        {
            foreach (var slot in slots)
            {
                if (slot.gameObject.name.Equals(weaponSlot))
                {
                    slot.EndSlotUsage();
                    break;
                }
            }
        }
    }
    
    
    
    
}
