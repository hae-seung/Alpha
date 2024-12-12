using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI itemCountTxt;
    
    private CountableItem item;
    private Slot parentSlot;
    
    public void SetUp(CountableItem newItem, Slot slot)
    {
        parentSlot = slot;
        item = newItem;
        itemIcon.sprite = item.Data.IconImage;
        itemCountTxt.text = newItem.Amount.ToString();
    }

    public void UpdateAmount()
    {
        itemCountTxt.text = item.Amount.ToString();
    }
    
    public Item GetItem()
    {
        return item;
    }
    
    public bool ModifyItemAmount()
    {
        if (!item.IsEmpty)
        {
            itemCountTxt.text = item.Amount.ToString();
            return false;
        }
        else
            return true;
    }

    public void RemoveItemUI()
    {
        parentSlot.RemoveItem();
        Destroy(gameObject);
    }
}
