using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    private List<Item> items = new List<Item>();
    
    
    public IReadOnlyList<Item> Items => items.AsReadOnly();
    public void SetInventory(List<Item> _items)
    {
        items.Clear();
        items = new List<Item>(_items);
    }
}
