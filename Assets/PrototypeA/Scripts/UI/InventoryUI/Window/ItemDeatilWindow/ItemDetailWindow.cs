using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDetailWindow : MonoBehaviour
{
    public ItemInfoSet itemInfoSet;
    public ItemAbilitySet itemAbilitySet;
    public ItemDescriptionSet itemDescriptionSet;
    public ItemUseBtnSet itemUseBtnSet;



    public void Open(ItemUI itemUI)
    {
        if(!gameObject.activeSelf)
            gameObject.SetActive(true);
        
        Item item = itemUI.GetItem();
        
        itemInfoSet.UpdateInfo(item);
        //itemAbilitySet.UpdateAbility();
        itemDescriptionSet.UpdateDescription(item);
        itemUseBtnSet.SetUpBtn(itemUI, this);
    }
   
}
