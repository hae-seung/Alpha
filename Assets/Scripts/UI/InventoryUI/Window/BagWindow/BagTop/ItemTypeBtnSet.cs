using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTypeBtnSet : MonoBehaviour
{
    [Header("항상 켜지면 디폴트 값으로 선택되는 것")]
    public TextMeshProUGUI curSelectedBtnText;
    public GameObject curOpendItemList;
    
    public void onClickItemType(TextMeshProUGUI itemText, GameObject ItemList)
    {
        if (ItemList == curOpendItemList || itemText == curSelectedBtnText) return;
        ActiveBtnText(itemText);
        ActiveBagItemList(ItemList);
    }

    private void ActiveBagItemList(GameObject bagItemList)
    {
        curOpendItemList.SetActive(false);
        curOpendItemList = bagItemList;
        curOpendItemList.SetActive(true);
    }

    private void ActiveBtnText(TextMeshProUGUI itemText)
    {
        curSelectedBtnText.gameObject.SetActive(false);
        curSelectedBtnText = itemText;
        curSelectedBtnText.gameObject.SetActive(true);
    }
}
