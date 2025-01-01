using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rect;
    public Image image;
    public GameObject itemUIPrefab;
    private ItemUI itemUI;
    private SlotHolder parentSlotHolder;

    public bool IsUsing { get; private set; } = false;

    public void SetUp(Item newItem, SlotHolder slotHolder)
    {
        parentSlotHolder = slotHolder;
        IsUsing = true;
        itemUI = Instantiate(itemUIPrefab, rect).GetComponent<ItemUI>();
        itemUI.SetUp(newItem, this);
        itemUI.OnDestroyItemUI += EndSlotUsage;
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
        {
            itemUI.OnDestroyItemUI -= EndSlotUsage;
            Destroy(itemUI.gameObject);
            itemUI = null;
        }

        IsUsing = false;
        image.color = Color.white;
        parentSlotHolder.FreeSlot();
    }
}
