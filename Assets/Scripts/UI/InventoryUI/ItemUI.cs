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
    public Item item;

    
    public void SetUp(CountableItem newItem)
    {
        item = newItem;
        itemIcon.sprite = item.Data.IconImage;
        itemCountTxt.text = newItem.Amount.ToString();
    }

    
}
