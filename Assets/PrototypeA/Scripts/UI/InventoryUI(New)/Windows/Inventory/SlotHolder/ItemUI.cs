using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private TextMeshProUGUI itemCountTxt;
    private Image itemImage;
    private Item item;
    private Slot parentSlot;
    private EquipSlot parentEquipSlot;

    private bool isEquipped;
    
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;


    
    public void SetUp(Item newItem, Slot slot)
    {
        itemCountTxt = GetComponentInChildren<TextMeshProUGUI>();
        itemImage = GetComponent<Image>();

        isEquipped = false;
        parentSlot = slot;
        item = newItem;
        itemImage.sprite = item.Data.IconImage;

        if (newItem is CountableItem citem)
        {
            citem.OnUpdateItemCount += UpdateCountText;
            itemCountTxt.text = citem.Amount.ToString();
        }
        else
            itemCountTxt.text = "";
    }
    
    public void SetUp(Item newItem, EquipSlot slot)//장착 아이템에 대해 오버로딩
    {
        itemCountTxt = GetComponentInChildren<TextMeshProUGUI>();
        itemImage = GetComponent<Image>();

        parentEquipSlot = slot;
        isEquipped = true;
        item = newItem;
        itemImage.sprite = item.Data.IconImage;
        
        itemCountTxt.text = "";
    }

    private void UpdateCountText(int amount)
    {
        itemCountTxt.text = amount.ToString();
    }


    public Item GetItem()
    {
        return item;
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            EquipOrUseItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= doubleClickThreshold)
            {
                EquipOrUseItem();
            }
            lastClickTime = Time.time;
        }
    }

    private void EquipOrUseItem()
    {
        if (item == null)
        {
            Debug.LogError("Item is null in ItemUI.EquipOrUseItem.");
            return;
        }

        if (item is IUseable useableItem)//포션 아이템만 걸러짐
        {
            int amount = useableItem.Use();
            if (amount <= 0)
                item.RemoveItemFromInventory(item); //인벤토리 딕셔너리에서 아이템, UI 제거
            else
                UpdateCountText(amount);//text 수정(감소)
        }
        else if (item is IEquippable equipItem)
        {
            if (!isEquipped)
                equipItem.EquipOrSwapItem(item);//딕셔너리 제거 + UI 제거
            else
            {
                isEquipped = false;
                equipItem.UnEquipItem(item);
            }
        }
    }

}
