using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : EquipItem
{
   private ArmorItemData data;

   public ArmorItem(ArmorItemData data) : base(data)
   {
      this.data = data;
   }

   public ArmorType GetArmorType()
   {
      return data.GetArmorType();
   }
}
