using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionItem : CountableItem, IConsumable, IUseable, IBattleUseable
{
    private PortionItemData portionItemData;
    
    public PortionItem(PortionItemData data, int amount = 1) : base(data, amount)
    {
        portionItemData = data;
    }
    
    protected override CountableItem CloneItem(int amount)
    {
        return new PortionItem(CountableData as PortionItemData, amount);
    }
    
    public int Use()
    {
        if (Amount <= 0)
            return 0;
        
        Amount--;
        
        //todo:회복 로직 필요
        
        return Amount;
    }

    public ConsumeType GetConsumeType()
    {
        return portionItemData.GetConsumeType;
    }

    public CountableItem GetItem()
    {
        return this as PortionItem;
    }

    public StatType GetStatType => portionItemData.GetStatType;
    public int GetValue => portionItemData.GetValue;
}