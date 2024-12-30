using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public ItemManagerDirector itemManagerDirector;//방어구 악세서리 무기 소비 미션 총 관리자
    
    private bool isActive = false;
    

    public void AddItemAmount(CountableItem citem)
    {
       citem.UpdateItemCount();
    }
    
    public void CreateNewItem(Item newItem, int stackIdx)
    {
        switch (newItem)
        {
            case ArmorItem armorItem :
                itemManagerDirector.CreateArmorItem(armorItem);
                break;
        }
    }
    
    
    public void ActiveInventory()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }
}
