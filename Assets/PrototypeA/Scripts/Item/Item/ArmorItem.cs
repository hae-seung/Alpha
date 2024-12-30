using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : EquipItem<ArmorType>
{
   private ArmorItemData data;

   public ArmorItem(ArmorItemData data) : base(data)
   {
      this.data = data;
   }

   public override ArmorType ItemType()
   {
      return data.GetArmorType();
   }
   
}
