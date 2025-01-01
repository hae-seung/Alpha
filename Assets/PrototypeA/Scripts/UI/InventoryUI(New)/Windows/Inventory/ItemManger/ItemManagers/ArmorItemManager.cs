using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ArmortypeSlotHolder : SerializableDictionary<ArmorType, SlotHolder> {}

public class ArmorItemManager : MonoBehaviour
{
   //todo: 방어구 부위별 슬롯 홀더들
   
   public SlotHolder allItems;//전체 탭은 따로 빼둠
   public ArmortypeSlotHolder datas; //딕셔너리임
   
   public void CreateItem(ArmorItem armorItem)
   {
      ArmorType type = armorItem.GetItemTypeValue();
      
      allItems.CreateNewItem(armorItem);
      datas[type].CreateNewItem(armorItem);
   }

   public void RemoveItem(ArmorItem armorItem)
   {
      ArmorType type = armorItem.GetItemTypeValue();

      allItems.RemoveItem(armorItem);
      datas[type].RemoveItem(armorItem);
   }
}
