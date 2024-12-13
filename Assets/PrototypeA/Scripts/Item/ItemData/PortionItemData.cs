using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PortionItemData", menuName = "SO/ItemData/PortionItemData", order = int.MaxValue)]
public class PortionItemData : CountableItemData
{
    [SerializeField] private StatModifier statModifier;
    
    public StatType GetStatType => statModifier.statType;
    public int GetValue => statModifier.value;
    
    
    
}
