using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagWindow : MonoBehaviour
{
   [Header("항상 켜지면 디폴트 값으로 선택되는 것")]
   public Button defaultBtn;
   public GameObject defaultBagItem;
   
   private void OnEnable()
   {
      EventSystem.current.SetSelectedGameObject(defaultBtn.gameObject);
      defaultBagItem.SetActive(true);
   }
   
}
