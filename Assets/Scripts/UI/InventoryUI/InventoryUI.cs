using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("선택창들")]
    public GameObject[] inventoryWindows;

    [Header("아이템디테일 창")] 
    public GameObject itemDetailWindow;

    [Header("아이템 분류기")]
    public WeaponWindow weponManger;
    public BagWindow bagManager;

    [Header("모든 아이템 슬롯")]
    private List<Slot> allItemSlots = new List<Slot>();
    
    public void CreateNewItem(Item newItem, int idx, int stackIdx)
    {
        CountableItem citem = newItem as CountableItem;
        if (citem != null)
            bagManager.ClassifyItem(citem, idx, stackIdx);
        else
        {
            
        }
    }

    public void AddSlot(Slot newSlot)
    {
        allItemSlots.Add(newSlot);
    }
    
    public void ActiveWindow(int index)
    {
        gameObject.SetActive(true);
        itemDetailWindow.SetActive(false);
        for (int i = 0; i < inventoryWindows.Length; i++)
        {
            if(i == index)
                inventoryWindows[i].SetActive(true);
            else
                inventoryWindows[i].SetActive(false);
        }
    }
}
