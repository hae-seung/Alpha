using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rect;
    public Image image;
    public GameObject itemUIPrefab;
    private ItemUI itemUI;

    public bool IsUsing { get; private set; } = false;

    public void SetUp(Item newItem)
    {
        IsUsing = true;
        itemUI = Instantiate(itemUIPrefab, rect).GetComponent<ItemUI>();
        itemUI.SetUp(newItem, this);
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

    public void EndSlotUsage()
    {
        IsUsing = false;
        itemUI = null;
        image.color = Color.white;
    }
}
