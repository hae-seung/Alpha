using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemPanel : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public ArmorAccSlotHolder armorHolder;
    public ArmorAccSlotHolder accHolder;
    public WeaponSlotHolder weaponHolder;

    public void WearItem(Item item, string weaponSlot)
    {
        switch (item)
        {
            case ArmorItem armorItem:
                armorHolder.WearItem(armorItem);
                break;
            case AccItem accItem:
                accHolder.WearItem(accItem);
                break;
            case WeaponItem weaponItem:
                weaponHolder.WearItem(item, weaponSlot);
                break;
        }
    }


    public void UnWearItem(Item item, string weaponSlot)
    {
        switch (item)
        {
            case ArmorItem armorItem:
                armorHolder.UnWearItem(armorItem);
                break;
            case AccItem accItem:
                accHolder.UnWearItem(accItem);
                break;
            case WeaponItem weaponItem:
                weaponHolder.UnWearItem(item, weaponSlot);
                break;
        }
    }
}
