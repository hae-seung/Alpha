using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private Sprite emptySlotImage;
    [SerializeField] private Sprite fillSlotImage;
    private Item item = null;
    
    
    public bool IsUsing => item != null;
    
    private void ShowItem() => itemImage.gameObject.SetActive(true);
    private void ShowText() => amountText.gameObject.SetActive(true);

    private void HideItem() => itemImage.gameObject.SetActive(false);
    private void HideText() => amountText.gameObject.SetActive(false);


    public void SetUp(Item newItem)
    {
        item = newItem;
        itemImage.sprite = item.Data.IconImage;
        slotImage.sprite = fillSlotImage;
        ShowItem();

        if (item is CountableItem citem)
        {
            amountText.text = citem.Amount.ToString();
            ShowText();
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void EndSlotUsage()
    {
        item = null;
        slotImage.sprite = emptySlotImage;
        HideItem();
        HideText();
    }
    
    public void Highlight(bool enable)
    {
        slotImage.color = enable ? Color.red : Color.white;
    }
    
    public void UpdateCountText(int amount)
    {
        amountText.text = amount.ToString();
    }
}
