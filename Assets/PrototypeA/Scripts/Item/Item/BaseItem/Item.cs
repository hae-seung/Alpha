using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
   public ItemData Data { get; private set; }

   public Item(ItemData data) => Data = data;

   public event Action<Item> OnInventoryItemRemove;
   public event Action<Item> OnEquipOrSwapItem;
   
   private void RemoveItemFromInventory(Item item)//소비아이템 소모시 자동 발생 CountableItem 클래스에서 호출
   {
      OnInventoryItemRemove?.Invoke(item);
   }

   public void InvokeEquipOrSwapItem(Item item)
   {
      OnEquipOrSwapItem?.Invoke(item);
   }
}
