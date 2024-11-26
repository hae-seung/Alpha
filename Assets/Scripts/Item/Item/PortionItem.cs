using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionItem : CountableItem, IUseableItem
{
    public PortionItem(PortionItemData data, int amount = 1) : base(data, amount){}
    
    public bool Use()
    {
        Amount--;
        //todo: data의 value값만큼 플레이어에게 적용
        return true;
    }
}
