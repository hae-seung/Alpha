using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmorType
{
    Head,    // 머리
    Chest,   // 상의
    Legs,    // 하의
    Gloves,  // 장갑
    Shield,  // 방패
    Boots,   // 신발
    Cloak,   // 망토
    Epaulet  // 견장
}

[System.Serializable]
public class StatModifier
{
    public StatType statType;
    public int value;
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
}
