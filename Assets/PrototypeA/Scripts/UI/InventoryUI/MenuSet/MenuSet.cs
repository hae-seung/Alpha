using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSet : MonoBehaviour
{
   public Button defaultBtn;
   public void OnEnable()
   {
      EventSystem.current.SetSelectedGameObject(defaultBtn.gameObject);
      defaultBtn.GetComponent<MenuBtn>().SetUIText();
   }
   
   
}
