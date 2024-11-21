using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionItemData : CountableItemData
{
    [SerializeField] private int value;

    public int Value => value;
}
