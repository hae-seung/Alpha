using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccSlot : EquipSlot
{
    public AccType accType;
    
    public override Enum GetSlotType()
    {
        return accType;
    }
}
