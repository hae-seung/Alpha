using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponItem : EquipItem<WeaponType>
{
    private WeaponItemData weaponItemData;
    protected WeaponType type;
    
    public WeaponItem(WeaponItemData data) : base(data)
    {
        weaponItemData = data;
        type = data.GetWeaponType();
    }
    
    public override WeaponType GetItemTypeValue()
    {
        return type;
    }
    
    
}