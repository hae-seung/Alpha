using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemManagerDirector itemManagerDirector;//방어구 악세서리 무기 소비 미션 총 관리자
    public EquipItemPanel equipItemPanel;
    

    public void AddItemAmount(CountableItem citem)
    {
       citem.UpdateItemCount();
    }
    
    public void CreateNewItem(Item newItem, int stackIdx)
    {
        itemManagerDirector.CreateNewItem(newItem);
    }
    
    public void RemoveItemAllTabs(Item item)//인벤토리에서 제거
    {
        itemManagerDirector.RemoveItemAllTabs(item);
    }

    public void WearItem(Item item, string weaponSlot = null)//장착 UI에 생성
    {
        equipItemPanel.WearItem(item, weaponSlot);
    }

    public void UnWearItem(Item item, string weaponSlot = null)//장착UI에서 제거
    {
        equipItemPanel.UnWearItem(item, weaponSlot);
    }
    
    
    public void ActiveInventory(bool state)
    {
        gameObject.SetActive(state);
    }
}
