using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    private Inventory inventory;
    private Dictionary<int, List<Item>> items;
    private EquippedItem equippedItem;
    
    private void Start()
    {
        InitInventory();
    }

    private void InitInventory()
    {
        if (PlayerManager.Instance.inventory == null)
        {
            inventory = new Inventory();
        }
        else
        {
            inventory = PlayerManager.Instance.inventory;
        }
        
        items = inventory.GetItem;
        equippedItem = inventory.GetEquippedItem;
    }


    
    public void AddItem(Item newItem, int amount = 1)
    {
        int itemId = newItem.Data.Id;
        if (newItem is CountableItem countableItem)
        {
            if (items.ContainsKey(itemId))//동일 아이템 발견
            {
                CountableItem existingItem = null;
                int stackIndex = 0;
                for (; stackIndex < items[itemId].Count; stackIndex++)
                {
                    CountableItem citem = items[itemId][stackIndex] as CountableItem;
                    if (citem != null && !citem.IsMax)
                    {
                        existingItem = citem;
                        break;
                    }
                }
                
                if (existingItem != null)//갯수가 다 채워지지 않은 아이템 발견
                {
                    int excessAmount = existingItem.AddAmountAndGetExcess(amount);
                    UpdateItemCount(existingItem);//수량 추가후 바로 UI 업데이트
                    
                    if (excessAmount != 0)//수량을 추가하자 max를 찍고 더 나온 경우
                    {
                        CountableItem newCountableItem = countableItem.Clone(excessAmount);
                        items[itemId].Add(newCountableItem);
                        
                        //UI에 새로운 아이템 생성
                        CreateNewItem(newCountableItem, stackIndex + 1);
                    }
                }
                else //리스트 아이템이 가득찬 경우
                {
                    CountableItem newCountableItem = countableItem.Clone(amount);
                    items[itemId].Add(newCountableItem);
                    
                    //UI에 새로운 아이템 생성
                    CreateNewItem(newCountableItem,stackIndex + 1);
                }
                
            }
            else //딕셔너리에 없는 아예 새로운 아이템인 경우
            {
                items[itemId] = new List<Item>();
                items[itemId].Add(newItem);
                
                //UI에 새로운 아이템 생성
                CreateNewItem(newItem, 0);
            }
        }
        else//방어구 무기 류
        {
            if (!items.ContainsKey(itemId))
                items[itemId] = new List<Item>();
            
            items[itemId].Add(newItem);
            CreateNewArmorItem(newItem, items.Count - 1);
        }
    }
    
    private void UpdateItemCount(CountableItem citem)
    {
        inventoryUI.AddItemAmount(citem);
    }

    private void CreateNewItem(Item newItem, int stackIdx)
    {
        newItem.OnInventoryItemRemove += RemoveItem; 
        inventoryUI.CreateNewItem(newItem,stackIdx);
    }

    private void CreateNewArmorItem(Item newItem, int stackIdx)
    {
        newItem.OnEquipOrSwapItem += EquipOrSwapItem;
        inventoryUI.CreateNewItem(newItem,stackIdx);
    }

    private void RemoveItem(Item item)
    {
        item.OnInventoryItemRemove -= RemoveItem;//리스트에서 제거될때 구독해지
        if (items.TryGetValue(item.Data.Id, out List<Item> itemList))
        {
            itemList.Remove(item);
            inventoryUI.RemoveItemAllTabs(item);
        }
    }

    private void EquipOrSwapItem(Item item)
    {
        // 1. 이벤트 해제 및 인벤토리에서 제거
        HandleItemRemoval(item);

        if (item is WeaponItem weaponItem) // 무기류
        {
            EquipWeaponItem(weaponItem);
        }
        else // 방어구나 장신구
        {
            EquipNonWeaponItem(item);
        }
    }


    // **무기 장착 로직**
    private void EquipWeaponItem(WeaponItem weaponItem)
    {
        WeaponType weaponType = weaponItem.GetItemTypeValue();

        if (weaponType == WeaponType.MainWeapon) // 메인 무기
        {
            EquipMainWeaponItem((MainWeaponItem)weaponItem);
        }
        else // 서브 무기
        {
            EquipSubWeaponItem((SubWeaponItem)weaponItem);
        }
    }


    // **메인 무기 장착 로직**
    private void EquipMainWeaponItem(MainWeaponItem weaponItem)
    {
        WeaponGripType gripType = weaponItem.GetWeaponGripType;

        if (gripType == WeaponGripType.DoubleHand) // 양손 무기
        {
            HandleDoubleHandWeapon(weaponItem);
        }
        else // 한손 무기
        {
            HandleSingleHandWeapon(weaponItem);
        }
    }


    // **양손 무기 장착 로직**
    private void HandleDoubleHandWeapon(MainWeaponItem weaponItem)
    {
        var (mainWeapon, subWeapon) = equippedItem.EquipDoubleHandWeapon(weaponItem);
        //메인 서브 슬롯 강제 해제
        UnsubscribeAndStore(mainWeapon, "MainSlot");
        UnsubscribeAndStore(subWeapon, "SubSlot");

        inventoryUI.WearItem(weaponItem, "DoubleHandSlot");
        SubscribeToUnequipEvent(weaponItem);
    }

    // **한손 무기 장착 로직**
    private void HandleSingleHandWeapon(MainWeaponItem weaponItem)
    {
        if (equippedItem.IsDoubleHand) // 기존에 양손 무기가 장착된 경우
        {
            UnEquipItem(equippedItem.GetMainWeapon()); // 양손무기 강제 해제
        }

        var (previousItem, slotName) = equippedItem.EquipSingleHandWeapon(weaponItem);
        UnsubscribeAndStore(previousItem, slotName);

        inventoryUI.WearItem(weaponItem, slotName);
        SubscribeToUnequipEvent(weaponItem);
    }

    // **서브 무기 장착 로직**
    private void EquipSubWeaponItem(SubWeaponItem weaponItem)
    {
        if (equippedItem.IsDoubleHand) // 기존에 양손 무기가 장착된 경우
        {
            UnEquipItem(equippedItem.GetMainWeapon()); // 양손무기 강제 해제
        }
        var previousItem = equippedItem.EquipSubWeapon(weaponItem);
        UnsubscribeAndStore(previousItem, "SubSlot");

        inventoryUI.WearItem(weaponItem, "SubSlot");
        SubscribeToUnequipEvent(weaponItem);
    }

    // **방어구 및 장신구 장착 로직**
    private void EquipNonWeaponItem(Item item)
    {
        var (previousItem, isSwapped) = equippedItem.EquipOrSwapItem(item);

        if (isSwapped)
        {
            UnsubscribeAndStore(previousItem, null);
        }

        inventoryUI.WearItem(item);
        SubscribeToUnequipEvent(item);
    }

    // **아이템 제거 처리**
    private void HandleItemRemoval(Item item)
    {
        item.OnEquipOrSwapItem -= EquipOrSwapItem;
        RemoveItem(item);
    }

    // **이벤트 구독 해제 및 인벤토리에 추가**
    private void UnsubscribeAndStore(Item item, string slotName)
    {
        if (item != null)
        {
            item.OnUnequipItem -= UnEquipItem;
            inventoryUI.UnWearItem(item, slotName);
            AddItem(item);
        }
    }

    // **이벤트 구독**
    private void SubscribeToUnequipEvent(Item item)
    {
        item.OnUnequipItem += UnEquipItem;
    }

    // **아이템 해제 로직**
    private void UnEquipItem(Item item)
    {
        item.OnUnequipItem -= UnEquipItem;
        string slotName = equippedItem.RemoveItem(item);
        inventoryUI.UnWearItem(item, slotName);
        AddItem(item);
    }


   
    public void GetInventoryFromManager()
    {
        
    }
    public void SetInventoryToManager()
    {
        
    }
    
}
