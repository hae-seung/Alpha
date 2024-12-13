using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoSet : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image itemIcon;

    
    public void UpdateInfo(Item item)
    {
        itemName.text = item.Data.Name;
        itemIcon.sprite = item.Data.IconImage;
    }
}
