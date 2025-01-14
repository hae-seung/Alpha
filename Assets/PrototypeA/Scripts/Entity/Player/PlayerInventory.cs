using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    private Dictionary<int, List<Item>> items;
    
    private void Start()
    {
        InitInventory();
    }

    private void InitInventory()
    {
        Debug.Log("인벤토리 초기화 성공");
        if (PlayerManager.Instance.inventory.Item == null)
            items = new Dictionary<int, List<Item>>();
        else
        {
            items = new Dictionary<int, List<Item>>(PlayerManager.Instance.inventory.Item);
        }
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
                    if (excessAmount == 0)
                    {
                        //단순 갯수 UI 업데이트
                        UpdateItemCount(itemId, stackIndex);
                    }
                    else
                    {
                        //스택리스트에 새로 추가 excessAmount 만큼
                        CountableItem newCountableItem = countableItem.Clone(excessAmount);
                        items[itemId].Add(newCountableItem);
                        
                        //UI에 새로운 아이템 생성
                        CreateNewItem(newCountableItem, itemId, stackIndex + 1);
                    }
                }
                else //리스트 아이템이 가득찬 경우
                {
                    CountableItem newCountableItem = countableItem.Clone(amount);
                    items[itemId].Add(newCountableItem);
                    
                    //UI에 새로운 아이템 생성
                    CreateNewItem(newCountableItem, itemId, stackIndex + 1);
                }
                
            }
            else //딕셔너리에 없는 아예 새로운 아이템인 경우
            {
                items[itemId] = new List<Item>();
                items[itemId].Add(newItem);
                
                //UI에 새로운 아이템 생성
                CreateNewItem(newItem, itemId, 0);
            }
        }
        else//방어구 무기 류
        {
            if (!items.ContainsKey(itemId))
                items[itemId] = new List<Item>();
            
            items[itemId].Add(newItem);
            CreateNewItem(newItem, itemId, items.Count - 1);
        }
    }

    public void RemoveItem(int idx, int stackIdx)
    {
        items[idx].RemoveAt(stackIdx);
    }
    
    private void UpdateItemCount(int idx, int stackIdx)
    {
        inventoryUI.AddItemAmount(idx, stackIdx);
    }

    private void CreateNewItem(Item newItem, int idx, int stackIdx)
    {
        inventoryUI.CreateNewItem(newItem, idx, stackIdx);
    }

    public void GetInventoryFromManager()
    {
        
    }
    public void SetInventoryToManager()
    {
        
    }
    
}