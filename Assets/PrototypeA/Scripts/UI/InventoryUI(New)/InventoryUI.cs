using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemManagerDirector itemManagerDirector;//방어구 악세서리 무기 소비 미션 총 관리자
    public EquipItemPanel equipItemPanel;
    
    private bool isActive = false;
    

    public void AddItemAmount(CountableItem citem)
    {
       citem.UpdateItemCount();
    }
    
    public void CreateNewItem(Item newItem, int stackIdx)
    {
        itemManagerDirector.CreateNewItem(newItem);
    }

    public void WearItem(Item item)
    {
        equipItemPanel.WearItem(item);
    }

    public void RemoveItemAllTabs(Item item)
    {
        itemManagerDirector.RemoveItemAllTabs(item);
    }
    
    
    public void ActiveInventory()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }
}
