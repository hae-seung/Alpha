using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquippedItem
{
    private Dictionary<(Type enumType, Enum enumValue), Item> equippedItems = new();

    // 이미 장착된 아이템이 있는지 확인
    public (Item equippedItem, bool isSwapped) EquipOrSwapItem(Item item)
    {
        if (item is IEquippable equipItem)
        {
            var enumType = equipItem.GetItemType().GetType();
            var enumValue = equipItem.GetItemType();

            if (equippedItems.TryGetValue((enumType, enumValue), out var equippedItem))
            {
                equippedItems.Remove((enumType, enumValue));
                equippedItems[(enumType, enumValue)] = item;
                
                return (equippedItem, true);
            }
            else
            {
                equippedItems[(enumType, enumValue)] = item;
                return (null, false);
            }
        }

        Debug.LogError("[EquipOrSwapItem] Item is not an EquipItem.");
        return (null, false);
    }


    
   public void RemoveItem(Item item)//장착된 아이템만 장착해제하는 경우
   {
       // 키를 검색하고 제거
       var keyToRemove = equippedItems.FirstOrDefault(pair => pair.Value == item).Key;
       if (equippedItems.ContainsKey(keyToRemove))
       {
           equippedItems.Remove(keyToRemove);
           Debug.Log($"장착 해제: {item}");
       }
   }
}
