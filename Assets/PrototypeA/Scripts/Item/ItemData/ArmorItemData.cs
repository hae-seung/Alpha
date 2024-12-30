using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmorType
{
    Head,    // 머리
    Chest,   // 상의
    Pants,    // 하의
    Gloves,  // 장갑
    Boots,   // 신발
}


[CreateAssetMenu(fileName = "ArmorItemData", menuName = "SO/ItemData/ArmorItemData")]
public class ArmorItemData : EquipItemData
{
    [Tooltip("방어구 타입")]
    [SerializeField] private ArmorType armorType;
    
    [Tooltip("장비 장착시 증가하는 스텟선택")]
    [SerializeField] private List<StatModifier> statModifiers;

    [Tooltip("장비 강화 시 증가하는 스텟 값")]
    [SerializeField] private int enhanceIncrement;

    public ArmorType GetArmorType()
    {
        return armorType;
}
}
