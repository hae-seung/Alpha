using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseableItem
{
   public bool Use();
}

public interface IEquippable
{
   void EquipOrSwapItem(Item item);
   void UnEquipItem(Item item);
   Enum GetItemType();
}
