using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemData : CountableItemData
{
    public ConsumeType GetConsumeType => ConsumeType.Bomb;
}
