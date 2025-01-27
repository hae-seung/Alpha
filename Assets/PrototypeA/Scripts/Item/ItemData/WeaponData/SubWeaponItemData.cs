using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SubWeaponCategory
{
    Quiver,//화살통
    Magazine//탄창
}

public enum SubWeaponResourceType
{
    arrow,//화살류
    ammo//탄알류
}


[CreateAssetMenu(fileName = "SubWeapon", menuName = "SO/ItemData/WeaponItem/SubWeapon")]
public class SubWeaponItemData : WeaponItemData
{
    private WeaponType weaponType = WeaponType.SubWeapon;//고정값
    [SerializeField] private SubWeaponCategory category;
    [SerializeField] private SubWeaponResourceType needResource;

    public SubWeaponCategory Category => category;
    public SubWeaponResourceType NeedResource => needResource;
    
    public override WeaponType GetWeaponType()
    {
        return weaponType;
    }
}
