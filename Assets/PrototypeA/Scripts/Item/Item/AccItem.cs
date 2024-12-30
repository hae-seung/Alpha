using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccItem : EquipItem<AccType>
{
    private AccItemData data;
    
    public AccItem(AccItemData data) : base(data)
    {
        this.data = data;
    }


    public override AccType ItemType()
    {
        throw new NotImplementedException();
    } 
}
