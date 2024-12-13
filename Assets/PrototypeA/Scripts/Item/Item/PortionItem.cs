using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionItem : CountableItem, IUseableItem
{
    private PortionItemData portionItemData;
    
    public PortionItem(PortionItemData data, int amount = 1) : base(data, amount)
    {
        portionItemData = data;
    }
    
    
    public StatType GetStatType => portionItemData.GetStatType;
    public int GetValue => portionItemData.GetValue;
  
    
    public bool Use()
    {
        Amount--;
        //todo: data의 value값만큼 플레이어에게 적용
        return true;
    }
    
    
    
    
    protected override CountableItem CloneItem(int amount)
    {
        return new PortionItem(CountableData as PortionItemData, amount);
    }
}
