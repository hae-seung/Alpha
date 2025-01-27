using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotHolder : EquipSlotHolder
{
    public EquipSlot doubleHandSlot;
    public EquipSlot mainSlot;
    public EquipSlot subSlot;
    
    
    public override void WearItem(Item item, string weaponSlot = null)
    {
        switch (weaponSlot)
        {
            case "DoubleHandSlot" :
                doubleHandSlot.SetUpUI(item);
                break;
            case "MainSlot" :
                mainSlot.SetUpUI(item);
                break;
            case "SubSlot" :
                subSlot.SetUpUI(item);
                break;
        }
    }

    public override void UnWearItem(Item item, string weaponSlot = null)
    {
        switch (weaponSlot)
        {
            case "DoubleHandSlot" :
                EndSlotUsage(doubleHandSlot);
                break;
            case "MainSlot" :
                EndSlotUsage(mainSlot);
                break;
            case "SubSlot" :
                EndSlotUsage(subSlot);
                break;
        }
    }
}
