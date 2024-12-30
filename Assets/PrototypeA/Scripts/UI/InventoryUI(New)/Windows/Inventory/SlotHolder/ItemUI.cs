using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private TextMeshProUGUI itemCountTxt;
    private Image itemImage;
    private Item item;
    private Slot parentSlot;
    
    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;
    
    public void SetUp(Item newItem, Slot slot)
    {
        itemCountTxt = GetComponentInChildren<TextMeshProUGUI>();
        itemImage = GetComponent<Image>();

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

    private void UpdateCountText(int amount)
    {
        itemCountTxt.text = amount.ToString();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("아이템UI에 포인터 온!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("아이템UI에 포인터 아웃!");
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
        if (item is IUseableItem useableItem)
        {
            Debug.Log("아이템 사용!");
        }
        else if (item is IEquippable equipItem)
        {
            equipItem.EquipOrSwapItem(item);
            parentSlot.EndSlotUsage();
            Destroy(gameObject);
        }
    }
}
