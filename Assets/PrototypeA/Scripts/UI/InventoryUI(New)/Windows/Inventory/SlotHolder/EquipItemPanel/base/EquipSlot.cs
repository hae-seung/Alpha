using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class EquipSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rect;
    public Image image;
    public GameObject itemUIPrefab;
    private ItemUI itemUI;

    public bool IsUsing { get; private set; } = false;
    
    public void SetUpUI(Item item)
    {
        if(!IsUsing)
        {
            IsUsing = true;
            itemUI = Instantiate(itemUIPrefab, rect).GetComponent<ItemUI>();
            itemUI.SetUp(item, this);
            itemUI.OnDestroyItemUI += EndSlotUsage;
        }
        else
        {
            itemUI.UpdateItemUI(item);
        }
    }

    public void EndSlotUsage()
    {
        if (itemUI != null)
        {
            itemUI.OnDestroyItemUI -= EndSlotUsage;
            Destroy(itemUI.gameObject);
            itemUI = null;
        }
        
        IsUsing = false;
        itemUI = null;
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }
    
    public abstract Enum GetSlotType();
    
}
