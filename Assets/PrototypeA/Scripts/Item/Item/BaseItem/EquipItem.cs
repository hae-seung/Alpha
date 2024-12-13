using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : Item
{
   public EquipItemData EquipData { get; private set; }
   private int durability;
   public int Durability
   {
      get => durability;
      set
      {
         if (value <= 0)
            value = 0;
         if (value >= EquipData.MaxDurability)
            value = EquipData.MaxDurability;

         durability = value;
      }
   }
   
   public EquipItem(EquipItemData data) : base(data)
   {
      EquipData = data;
      Durability = data.MaxDurability;
   }
   
   
}
