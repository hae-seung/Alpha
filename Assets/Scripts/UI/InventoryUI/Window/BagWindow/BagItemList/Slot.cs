using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public RectTransform rect;
   public Image image;
   public GameObject itemPrefab;
   
   private int index;
   private int stackIndex;
   
   private ItemUI itemUI;
   private ItemSlotManager parentSlotManager;

   
   public int Index => index;
   public int StackIndex => stackIndex;
   
   public bool IsUsing { get; private set; } = false;

   
   public void SetUp(CountableItem newItem, int idx, int stackIdx, ItemSlotManager manager)
   {
      IsUsing = true;
      index = idx;
      stackIndex = stackIdx;
      parentSlotManager = manager;

      itemUI = Instantiate(itemPrefab, rect).GetComponent<ItemUI>();
      itemUI.SetUp(newItem, this);
   }

   public void AddItemAmount()
   {
      itemUI.UpdateAmount();
   }


   public void RemoveItem()
   {
      IsUsing = false;
      parentSlotManager.RemoveSlot(index, stackIndex, this);
   }

   public void OnPointerEnter(PointerEventData eventData)
   {
      if (IsUsing)
         image.color = Color.red;
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      if (IsUsing)
         image.color = Color.white;
   }
   
   public void OnClickSlot()
   {
      if (!IsUsing)
         return;

      parentSlotManager.OpenItemDetailWindow(itemUI);
   }
}
