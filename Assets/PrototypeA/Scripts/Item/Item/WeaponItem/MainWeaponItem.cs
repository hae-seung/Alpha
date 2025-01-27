using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeaponItem : WeaponItem
{
    private MainWeaponItemData data;

    public bool IsNeedSubWeapon => data.isNeedSubWeapon;
    public SubWeaponCategory GetSubWeaponCategory => data.GetSubWeaponType;
    public WeaponGripType GetWeaponGripType => data.GetWeaponGripType;
    
    
    public MainWeaponItem(MainWeaponItemData data) : base(data)
    {
        this.data = data;
    }
    
}
