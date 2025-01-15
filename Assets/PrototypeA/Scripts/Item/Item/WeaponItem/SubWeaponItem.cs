using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeaponItem : WeaponItem
{
    private SubWeaponItemData data;

    public SubWeaponCategory GetSubWeaponCategory => data.Category;
    public SubWeaponResourceType GetSubWeaponResource => data.NeedResource;
    
    
    public SubWeaponItem(SubWeaponItemData data) : base(data)
    {
        this.data = data;
    }
}
