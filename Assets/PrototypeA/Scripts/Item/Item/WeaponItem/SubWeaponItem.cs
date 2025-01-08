using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeaponItem : WeaponItem
{
    private SubWeaponItemData data;
    //type은 부모에서 선언
    
    public SubWeaponItem(SubWeaponItemData data) : base(data)
    {
        this.data = data;
        type = data.GetWeaponType();
    }
}
