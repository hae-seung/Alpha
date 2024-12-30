using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EquipItem<T> : Item, IEquippable where T : Enum
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
   
   public void EquipOrSwapItem(Item item)//인터페이스
   {
      InvokeEquipOrSwapItem(item);
   }

   public abstract T ItemType();

}
