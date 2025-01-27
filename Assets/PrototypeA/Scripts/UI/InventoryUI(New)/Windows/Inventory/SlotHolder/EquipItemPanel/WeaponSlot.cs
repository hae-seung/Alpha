using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : EquipSlot
{
    public WeaponType weaponType;
    
    public override Enum GetSlotType()
    {
        return weaponType;
    }
}
