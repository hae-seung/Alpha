using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSlot : EquipSlot
{
   public ArmorType armorType;
   
   
   
   
   public override Enum GetSlotType()
   {
      return armorType;
   }
}
