using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PortionItemData", menuName = "SO/ItemData/PortionItemData", order = int.MaxValue)]
public class PortionItemData : CountableItemData
{
    [SerializeField] private int value;

    public int Value => value;
}
