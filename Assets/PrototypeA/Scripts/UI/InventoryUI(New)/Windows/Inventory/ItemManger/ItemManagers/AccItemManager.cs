using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AcctypeSlotHolder : SerializableDictionary<AccType, SlotHolder> {}

public class AccItemManager : MonoBehaviour
{
   public SlotHolder allItems;
   public AcctypeSlotHolder datas; //딕셔너리임
   
   public void CreateItem(AccItem accItem)
   {
      AccType type = accItem.GetItemTypeValue();
      
      allItems.CreateNewItem(accItem);
      datas[type].CreateNewItem(accItem);
   }

   public void RemoveItem(AccItem accItem)
   {
      AccType type = accItem.GetItemTypeValue();
      
      allItems.RemoveItem(accItem);
      datas[type].RemoveItem(accItem);
   }
}
