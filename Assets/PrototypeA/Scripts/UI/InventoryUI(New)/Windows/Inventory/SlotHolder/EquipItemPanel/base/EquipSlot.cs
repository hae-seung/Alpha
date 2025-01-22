using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class EquipSlot : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private Image itemImage;
    private Item item = null;
    
    private void ShowItem() => itemImage.gameObject.SetActive(true);
    private void HideItem() => itemImage.gameObject.SetActive(false);
    
    public void SetUpUI(Item newItem)
    {
        item = newItem;
        itemImage.sprite = item.Data.IconImage;
        ShowItem();
    }

    public void EndSlotUsage()
    {
        item = null;
        HideItem();
    }
    
    public Item GetItem()
    {
        return item;
    }
    
    public void Highlight(bool enable)
    {
        slotImage.color = enable ? Color.red : Color.white;
    }
    
    public abstract Enum GetSlotType();
    
}
