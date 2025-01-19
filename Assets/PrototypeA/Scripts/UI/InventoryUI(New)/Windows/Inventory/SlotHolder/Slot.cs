using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rect;
    private Image image;
    private ItemUI itemUI;
    private SlotHolder parentSlotHolder;
    
    public GameObject itemUIPrefab;
    public Sprite emptySlotImage;
    public Sprite usingSlotImage;
    public bool IsUsing { get; private set; } = false;

    public void SetUp(Item newItem, SlotHolder slotHolder)
    {
        if (itemUI != null)//이미 한 번 사용된 적 있었다면
        {
            itemUI.gameObject.SetActive(true);
        }
        else//아예 새삥
        {
            rect = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        
            parentSlotHolder = slotHolder;
        
            itemUI = Instantiate(itemUIPrefab, rect).GetComponent<ItemUI>();
        }
        
        itemUI.SetUp(newItem, this);
        IsUsing = true;
        image.sprite = usingSlotImage;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsUsing)
            image.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsUsing)
            image.color = Color.white;
    }

    public Item GetItem()
    {
        return itemUI.GetItem();
    }
    
    public void EndSlotUsage()
    {
        if (itemUI != null)
            itemUI.gameObject.SetActive(false);
        
        IsUsing = false;
        image.color = Color.white;
        image.sprite = emptySlotImage;
        parentSlotHolder.FreeSlot();
    }
}
