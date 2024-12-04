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
   private int index;
   private int stackIndex;

   public GameObject itemPrefab;
   public int Index => index;
   public int StackIndex => stackIndex;
   
   public bool IsUsing { get; private set; } = false;

  

   public void SetUp(CountableItem newItem, int idx, int stackIdx)
   {
      Debug.Log("Slot셋업호출");
      IsUsing = true;
      index = idx;
      stackIndex = stackIdx;

      ItemUI item = Instantiate(itemPrefab, rect).GetComponent<ItemUI>();
      item.SetUp(newItem);
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
   
   public void Ooooooooo()
   {
      Debug.Log("버튼이 클릭크");
   }
}
