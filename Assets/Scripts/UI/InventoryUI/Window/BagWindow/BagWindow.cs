using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagWindow : MonoBehaviour
{
   [Header("항상 켜지면 디폴트 값으로 선택되는 것")]
   public Button defaultBtn;
   public GameObject defaultBagItem;
   
   [Header("아이템 분류기")]
   public PortionListManager PortionListManager;
   public ETCListManager ETCListManager;
   public QuestListManager QuestListManager;
   
   
   private void OnEnable()
   {
      EventSystem.current.SetSelectedGameObject(defaultBtn.gameObject);
      defaultBagItem.SetActive(true);
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
   
   
}
