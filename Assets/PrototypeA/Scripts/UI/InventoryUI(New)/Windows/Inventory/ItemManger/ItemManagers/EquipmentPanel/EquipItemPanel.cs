using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemPanel : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public EquipSlotHolder armorHolder;
    public EquipSlotHolder accHolder;
    //todo: 무기 추가

    public void WearItem(Item item)
    {
        switch (item)
        {
            case ArmorItem armorItem:
                armorHolder.WearItem(armorItem);
                break;
            case AccItem accItem:
                accHolder.WearItem(accItem);
                break;
        }
    }
    
    
}
