using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseBtnSet : MonoBehaviour
{
    public GameObject useBtn;

    private ItemDetailWindow parentDetailWindow;
    private IUseableItem item;
    private ItemUI itemUI;
    
    public void SetUpBtn(ItemUI itemUI, ItemDetailWindow parent)
    {
        Item _item = itemUI.GetItem();
        
        if (_item is IUseableItem iitem)
        {
            item = iitem;
            this.itemUI = itemUI;
            useBtn.SetActive(true);
        }
        else
        {
            useBtn.SetActive(false);
            item = null;
        }

        parentDetailWindow = parent;
    }


    public void OnClickUseBtn()
    {
        if (item == null)
            return;
        
        if (item.Use())
        {
            if (itemUI.ModifyItemAmount())
            {
                itemUI.RemoveItemUI();
                parentDetailWindow.gameObject.SetActive(false);
            }
        }
    }
}
