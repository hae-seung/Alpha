using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponItemManager : MonoBehaviour
{
   public SlotHolder doubleHandSlotHolder;
   public SlotHolder singleHandSlotHolder;
   public SlotHolder subWeaponSlotHolder;
   
   public void CreateItem(WeaponItem weaponItem)
   {
      switch (weaponItem.GetItemTypeValue())
      {
         case WeaponType.MainWeapon:
            HandleMainWeaponCreation(weaponItem as MainWeaponItem);
            break;

         case WeaponType.SubWeapon:
            subWeaponSlotHolder.CreateNewItem(weaponItem);
            break;
      }
   }
   
   public void RemoveItem(WeaponItem weaponItem)
   {
      switch (weaponItem.GetItemTypeValue())
      {
         case WeaponType.MainWeapon:
            HandleMainWeaponRemoval(weaponItem as MainWeaponItem);
            break;

         case WeaponType.SubWeapon:
            subWeaponSlotHolder.RemoveItem(weaponItem);
            break;
      }
   }

   
   
   private void HandleMainWeaponRemoval(MainWeaponItem mainWeaponItem)
   {
      if (mainWeaponItem == null) return;

      var gripType = mainWeaponItem.GetWeaponGripType;
      var targetSlotHolder = gripType == WeaponGripType.DoubleHand 
         ? doubleHandSlotHolder 
         : singleHandSlotHolder;

      targetSlotHolder.RemoveItem(mainWeaponItem);
   }

   
   private void HandleMainWeaponCreation(MainWeaponItem mainWeaponItem)
   {
      if (mainWeaponItem == null)
      {
         return;
      }
      
      WeaponGripType gripType = mainWeaponItem.GetWeaponGripType;
      SlotHolder targetSlotHolder = gripType == WeaponGripType.DoubleHand 
         ? doubleHandSlotHolder 
         : singleHandSlotHolder;
      
      targetSlotHolder.CreateNewItem(mainWeaponItem);
   }
}
