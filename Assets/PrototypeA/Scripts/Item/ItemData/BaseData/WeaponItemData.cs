using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum WeaponType
{
    MainWeapon,
    SubWeapon
}

public abstract class WeaponItemData : EquipItemData
{
    public abstract WeaponType GetWeaponType();
}
