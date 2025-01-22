using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorAccSlotHolder : EquipSlotHolder
{
    public List<EquipSlot> slots;
    public override void WearItem(Item item, string weaponSlot = null)
    {
        if(item is IEquippable eitem)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if(eitem.GetItemType().Equals(slots[i].GetSlotType()))
                {
                    slots[i].SetUpUI(item);
                    break;
                }
            }
        }
    }

    public override void UnWearItem(Item item, string weaponSlot = null)
    {
        if(item is IEquippable eitem)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if(eitem.GetItemType().Equals(slots[i].GetSlotType()))
                {
                    EndSlotUsage(slots[i]);
                    break;
                }
            }
        }
    }
}
