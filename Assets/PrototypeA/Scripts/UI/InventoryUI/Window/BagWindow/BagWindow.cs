using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagWindow : MonoBehaviour
{
   [Header("켜지면 모두 꺼지는 초기화 작업")] 
   public BagItemLists itemListParent;
   
   [Header("항상 켜지면 디폴트 값으로 선택되는 것")]
   public Button defaultBtn;
   public GameObject defaultBagItem;
   
   [Header("아이템 분류기")]
   public PortionListManager PortionListManager;
   public ETCListManager ETCListManager;
   public QuestListManager QuestListManager;

   [Header("아이템 디테일 스크립트")] 
   public ItemDetailWindow itemDetailWindow;
   
   
   private void OnEnable()
   {
      ActiveFalseWindows();
      
      defaultBagItem.SetActive(true);
      EventSystem.current.SetSelectedGameObject(defaultBtn.gameObject);
   }

   private void ActiveFalseWindows()
   {
      itemListParent.ActiveFalseAllWindow();
      itemDetailWindow.gameObject.SetActive(false);
   }


   public void ClassifyItem(CountableItem newItem, int idx, int stackIdx)
   {
      switch (newItem)
      {
         case PortionItem portionItem:
            PortionListManager.Classify(portionItem, idx, stackIdx);
            break;
         
         default:
            break;
      }
   }

   public void OpenItemDetailWindow(ItemUI itemUI)
   {
      itemDetailWindow.Open(itemUI);
   }
   
}
