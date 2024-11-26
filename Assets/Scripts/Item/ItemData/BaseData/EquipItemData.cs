using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipItemData : ItemData
{
   [SerializeField] private int maxDurability = 100;

   public int MaxDurability => maxDurability;
}
