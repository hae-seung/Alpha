using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EquippedItem
{
    private Dictionary<(Type enumType, Enum enumValue), Item> equippedItems = new();
    private WeaponItem mainWeapon = null; //현재 UI상태라고 생각해야함
    private WeaponItem subWeapon = null; //현재 UI상태라고 생각해야함
    
    public bool IsSwappable { get; private set; } = false;
    public bool IsDoubleHand { get; private set; } = false;
    public bool IsUseableSignatureSubWeapon { get; private set; } = false;
    
    public Item GetMainWeapon()
    {
        return mainWeapon;
    }
    

    #region 방어구 장신구 장착

    public (Item equippedItem, bool isSwapped) EquipOrSwapItem(Item item)
    {
        if (item is IEquippable equipItem)
        {
            var enumType = equipItem.GetItemType().GetType();
            var enumValue = equipItem.GetItemType();

            if (equippedItems.TryGetValue((enumType, enumValue), out var equippedItem))//같은 타입의 아이템이 있었다면
            {
                equippedItems.Remove((enumType, enumValue));
                equippedItems[(enumType, enumValue)] = item;

                return (equippedItem, true);
            }
            else//같은 타입의 아이템이 장착된 상태가 아니었다면
            {
                equippedItems[(enumType, enumValue)] = item;
                return (null, false);
            }
            
        }

        Debug.LogError("[EquipOrSwapItem] Item is not an EquipItem.");
        return (null, false);
    }

    #endregion
    

    #region 두손무기 장착

    public (Item mainWeapon, Item subWeapon) EquipDoubleHandWeapon(MainWeaponItem doubleGripWeapon)
    {
        WeaponItem temp1 = mainWeapon;
        mainWeapon = doubleGripWeapon;

        WeaponItem temp2 = subWeapon;
        subWeapon = null;

        IsDoubleHand = true;
        IsSwappable = false;
        IsUseableSignatureSubWeapon = false;
        
        return (temp1, temp2);
    }

    #endregion
    

    #region 한손무기 장착

    public (Item item, string slotName) EquipSingleHandWeapon(MainWeaponItem singleGripWeapon)
    {
        // 메인 무기가 비어있으면 메인 슬롯에 장착
        if (mainWeapon == null)
        {
            mainWeapon = singleGripWeapon;

            if (singleGripWeapon.IsNeedSubWeapon)
                ValidateSubWeaponCompatibility(singleGripWeapon);
            else
                UpdateStateForNoSubWeapon();

            return (null, "MainSlot");
        }

        // 서브 무기가 비어있으면 서브 슬롯에 장착
        if (subWeapon == null)
        {
            subWeapon = singleGripWeapon;
            SetState(isSwappable: true, isDoubleHand: false, isUseableSignatureSubWeapon: false);
            return (null, "SubSlot");
        }

        // 교체 자리가 없으면 메인에만 강제 장착
        WeaponItem temp = mainWeapon;
        mainWeapon = singleGripWeapon;

        if (singleGripWeapon.IsNeedSubWeapon)
            ValidateSubWeaponCompatibility(singleGripWeapon);
        else
            UpdateStateForNoSubWeapon();

        return (temp, "MainSlot");
    }

    // 보조 무기와 호환성을 검사하고 상태를 업데이트
    private void ValidateSubWeaponCompatibility(MainWeaponItem singleGripWeapon)
    {
        if (subWeapon is SubWeaponItem subWeaponItem &&
            subWeaponItem.GetSubWeaponCategory == singleGripWeapon.GetSubWeaponCategory)
        {
            //장착되어있던 보조무기와 호환됨
            SetState(isSwappable: false, isDoubleHand: false, isUseableSignatureSubWeapon: true);
        }
        else
        {
            UpdateStateForNoSubWeapon();//보조무기와 호완되지 않을때
        }
    }

    // 보조 무기가 필요 없는 경우
    private void UpdateStateForNoSubWeapon()
    {
        if (subWeapon == null)
        {
            SetState(isSwappable: false, isDoubleHand: false, isUseableSignatureSubWeapon: false);
        }
        else if (subWeapon is MainWeaponItem) // 서브 슬롯에 한손 무기가 장착된 경우
        {
            SetState(isSwappable: true, isDoubleHand: false, isUseableSignatureSubWeapon: false);
        }
        else // 호환되지 않는 보조무기가 있는 경우
        {
            SetState(isSwappable: false, isDoubleHand: false, isUseableSignatureSubWeapon: false);
        }
    }
    

    #endregion
    

    #region 진짜 보조무기류 장착

    public Item EquipSubWeapon(SubWeaponItem newSubWeapon)
    {
        // 상태 업데이트
        UpdateStateForSubWeapon(newSubWeapon);

        if (subWeapon == null) // 보조 무기 슬롯이 비어있는 경우
        {
            subWeapon = newSubWeapon;
            return null;
        }

        // 기존 보조 무기를 반환하고 새 보조 무기를 장착
        WeaponItem previousSubWeapon = subWeapon;
        subWeapon = newSubWeapon;
        
        return previousSubWeapon;
    }

    // 보조 무기 장착 시 상태 비교 및 업데이트
    private void UpdateStateForSubWeapon(SubWeaponItem newSubWeapon)
    {
        if (IsMainWeaponAbsent())
        {
            SetState(isSwappable: false, isDoubleHand: false, isUseableSignatureSubWeapon: false);
            return;
        }

        if (IsCompatibleWithMainWeapon(newSubWeapon))
        {
            SetState(isSwappable: false, isDoubleHand: false, isUseableSignatureSubWeapon: true);
        }
        else
        {
            SetState(isSwappable: false, isDoubleHand: false, isUseableSignatureSubWeapon: false);
        }
    }

    // 주무기 비어있는지 확인
    private bool IsMainWeaponAbsent()
    {
        return mainWeapon == null;
    }

    // 주무기와 보조 무기 호환성 검사
    private bool IsCompatibleWithMainWeapon(SubWeaponItem newSubWeapon)
    {
        return mainWeapon is MainWeaponItem mainWeaponItem &&
               mainWeaponItem.IsNeedSubWeapon &&
               newSubWeapon.GetSubWeaponCategory == mainWeaponItem.GetSubWeaponCategory;
    }


    #endregion
    

    #region 아이템 제거

    public string RemoveItem(Item item) // 장착된 아이템만 장착 해제하는 경우
    {
        if (item is WeaponItem weaponItem)
        {
            // 메인 무기 해제
            if (mainWeapon == weaponItem)
            {
                return RemoveMainWeapon();
            }

            // 서브 무기 해제
            if (subWeapon == weaponItem)
            {
                return RemoveSubWeapon();
            }
        }
        else
        {
            // 기타 아이템(방어구, 장신구 등) 해제
            var keyToRemove = equippedItems.FirstOrDefault(pair => pair.Value == item).Key;
            if (equippedItems.ContainsKey(keyToRemove))
            {
                equippedItems.Remove(keyToRemove);
                Debug.Log($"장착 해제: {item}");
            }
        }

        return null; // 아이템이 장착된 상태가 아니거나 해제할 필요 없는 경우
    }

    // 메인 무기 해제
    private string RemoveMainWeapon()
    {
        mainWeapon = null;
        UpdateStateForWeaponRemoval();

        if (IsDoubleHand)
        {
            IsDoubleHand = false;
            return "DoubleHandSlot";
        }
        return "MainSlot";
    }

    // 서브 무기 해제
    private string RemoveSubWeapon()
    {
        subWeapon = null;
        UpdateStateForWeaponRemoval();
        return "SubSlot";
    }

    // 무기 해제 시 상태 초기화
    private void UpdateStateForWeaponRemoval()
    {
        IsSwappable = false;
        IsUseableSignatureSubWeapon = false;
    }


    #endregion
    
    // 상태 설정 유틸리티 함수
    private void SetState(bool isSwappable, bool isDoubleHand, bool isUseableSignatureSubWeapon)
    {
        IsSwappable = isSwappable;
        IsDoubleHand = isDoubleHand;
        IsUseableSignatureSubWeapon = isUseableSignatureSubWeapon;
    }
}
