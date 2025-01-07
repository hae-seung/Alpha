using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PortionItem", menuName = "SO/ItemData/ConsumeItem/PortionItem")]
public class PortionItemData : CountableItemData
{
    [SerializeField]
    private StatModifier statModifier;//회복시킬 양
    
    public ConsumeType GetConsumeType => ConsumeType.Portion;
    public StatType GetStatType => statModifier.statType;
    public int GetValue => statModifier.value;
    
}
