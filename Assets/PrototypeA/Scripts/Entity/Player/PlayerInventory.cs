using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
            itemList.Remove(item);
    }

    private void EquipOrSwapItem(Item item)
    {
        // 구독 해제
        item.OnEquipOrSwapItem -= EquipOrSwapItem;
        // 인벤토리에서 제거
        RemoveItem(item);
        
        //인벤토리에서 빠져나갔으니 itemUI 파괴(allTab이 있어서 여기서 파괴)
        inventoryUI.RemoveItemAllTabs(item);

        var (isEquippedItem, isSwapped) = equippedItem.EquipOrSwapItem(item);
        if (isSwapped)
        {
            // 기존 아이템의 이벤트 해제
            isEquippedItem.OnUnequipItem -= UnEquipItem;
            // 기존 아이템 인벤토리에 추가
            AddItem(isEquippedItem);
            // 새 아이템 장착
            inventoryUI.WearItem(item);
            //새아이템에 대한 이벤트 구독
            item.OnUnequipItem += UnEquipItem;
        }
        else
        {
            // 새 아이템의 이벤트 구독
            item.OnUnequipItem += UnEquipItem;
            // 새 아이템 장착
            inventoryUI.WearItem(item);
        }

       
    }


    public void UnEquipItem(Item item)
    {
        //이벤트가 발생했으니 구독 해제
        item.OnUnequipItem -= UnEquipItem;

        // 딕셔너리에서 제거
        equippedItem.RemoveItem(item);

        // 인벤토리에 추가
        AddItem(item);

        Debug.Log($"Item {item} unequipped and added to inventory.");
    }

   
    public void GetInventoryFromManager()
    {
        
    }
    public void SetInventoryToManager()
    {
        
    }
    
}
