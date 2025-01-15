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
        if(itemUI == null)
        {
            itemUI = Instantiate(itemUIPrefab, rect).GetComponent<ItemUI>();
        }
        else//스왑이 된 경우 UI 재활용
        {
            itemUI.gameObject.SetActive(true);
        }
        IsUsing = true;
        itemUI.SetUp(item, this);
    }

    public void EndSlotUsage()
    {
        if (itemUI != null)
        {
            itemUI.gameObject.SetActive(false);
            Debug.Log("UI끔");
        }
        
        IsUsing = false;
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
