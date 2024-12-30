using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseableItem
{
   public bool Use();
}

public interface IEquippable
{
   public void EquipOrSwapItem(Item item);
}
