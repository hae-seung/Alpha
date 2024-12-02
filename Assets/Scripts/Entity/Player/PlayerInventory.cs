using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    private Dictionary<int, List<Item>> items;
    
    private void Awake()
    {
        PlayerManager.Instance.OnPlayerInitialized += InitInventory;
    }
    private void InitInventory(Character player)
    {
        Debug.Log("첫 인벤토리 초기화 성공");

        // player.inventory.Item이 null인 경우 빈 딕셔너리로 초기화
        if (player.inventory.Item == null)
        {
            items = new Dictionary<int, List<Item>>();
        }
        else
        {
            items = new Dictionary<int, List<Item>>(player.inventory.Item);
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
                        UpdateItemCount();
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
            
        }
    }

    private void UpdateItemCount()
    {
        
    }

    private void CreateNewItem(Item newItem, int idx, int stackIdx)
    {
        inventoryUI.CreateNewItem(newItem, idx, stackIdx);
    }

    public void GetInventoryFromManager()
    {
        items = new Dictionary<int, List<Item>>(PlayerManager.Instance.Player.inventory.Item);
    }
    public void SetInventoryToManager()
    {
        PlayerManager.Instance.Player.inventory.SetInventory(items);
    }
    
}