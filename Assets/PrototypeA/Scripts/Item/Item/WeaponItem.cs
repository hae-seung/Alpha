using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : EquipItem<WeponType>
{
   private WeaponItemData data;

   public WeaponItem(WeaponItemData data) : base(data)
   {
      this.data = data;
   }

   public override WeponType GetItemTypeValue()
   {
      throw new NotImplementedException();
   }
}
