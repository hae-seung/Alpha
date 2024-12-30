using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatModifier
{
   public StatType statType;
   public int value;
}

public abstract class EquipItemData : ItemData
{
   [SerializeField] private int maxDurability = 100;

   public int MaxDurability => maxDurability;
}
