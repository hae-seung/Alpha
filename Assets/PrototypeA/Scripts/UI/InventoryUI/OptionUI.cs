using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
   public InventoryUI inventoryUI;
   private bool isActive = false;
   
   
   public void ActiveInventoryUI()
   {
      isActive = !isActive;
      gameObject.SetActive(isActive);
   }

   public void onClickMenuBtn(int index)
   {
      gameObject.SetActive(false);
      inventoryUI.ActiveWindow(index);
   }
   
   
   
}
