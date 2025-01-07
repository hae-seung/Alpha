using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionItem : CountableItem
{
    private MissionItemData data;
    
    public MissionItem(MissionItemData data, int amount = 1) : base(data, amount)
    {
        this.data = data;
    }

    protected override CountableItem CloneItem(int amount)
    {
        return new MissionItem(CountableData as MissionItemData, amount);
    }
    
    
}
