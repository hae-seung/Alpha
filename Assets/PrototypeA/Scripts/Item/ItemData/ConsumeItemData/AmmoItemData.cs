using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItemData : CountableItemData
{
    public ConsumeType GetConsumeType => ConsumeType.Ammo;
}
