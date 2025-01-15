using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ConsumeTypeSlotHolder : SerializableDictionary<ConsumeType, SlotHolder> {}

public class ConsumeItemManager : MonoBehaviour
{
   public ConsumeTypeSlotHolder datas;
   
   public void CreateItem(IConsumable item)
   {
      ConsumeType type = item.GetConsumeType();
      datas[type].CreateNewItem(item.GetItem());
   }

   public void RemoveItem(IConsumable item)
   {
      ConsumeType type = item.GetConsumeType();
      datas[type].RemoveItem(item.GetItem());
   }
}
