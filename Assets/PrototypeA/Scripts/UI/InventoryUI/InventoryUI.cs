using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("선택창들")]
    public GameObject[] inventoryWindows;

    [Header("아이템 분류기")]
    public WeaponWindow weponManger;
    public BagWindow bagManager;

    [Header("플레이어 인벤토리")] 
    public PlayerInventory playerInventory;

    [Header("모든 사용중인 아이템 슬롯")]
    private List<Slot> allItemSlots = new List<Slot>();
    
    private bool isActive = false;
    
    public void CreateNewItem(Item newItem, int idx, int stackIdx)
    {
        CountableItem citem = newItem as CountableItem;
        if (citem != null)
            bagManager.ClassifyItem(citem, idx, stackIdx);
        else
            weponManger.Classify(newItem as EquipItem, idx, stackIdx);
    }

    public void AddItemAmount(int idx, int stackIdx)
    {
        for (int i = 0; i < allItemSlots.Count; i++)
        {
            if((allItemSlots[i].Index == idx && allItemSlots[i].StackIndex == stackIdx))
            {
                allItemSlots[i].AddItemAmount();
                break;
            }
        
        }
    }
    
    public void RemoveItem(int idx, int stackIdx, Slot slot)
    {
        allItemSlots.Remove(slot);
        playerInventory.RemoveItem(idx, stackIdx);
    }
    
    public void AddSlot(Slot newSlot)
    {
        allItemSlots.Add(newSlot);
    }
    
    public void ActiveWindow(int index)
    {
        gameObject.SetActive(true);
        
        for (int i = 0; i < inventoryWindows.Length; i++)
        {
            if(i == index)
                inventoryWindows[i].SetActive(true);
            else
                inventoryWindows[i].SetActive(false);
        }
    }

    public void OpenItemDetailWindow(ItemUI itemUI)
    {
        bagManager.OpenItemDetailWindow(itemUI);
    }

    public void ActiveInventory()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }
}
