using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Inventory
{
    private Dictionary<int, List<Item>> items = new Dictionary<int, List<Item>>();
    private EquippedItem equippedItem = new EquippedItem();
    
    
    
    public Dictionary<int, List<Item>> GetItem => items;
    public EquippedItem GetEquippedItem => equippedItem;
    
    
    
    
    public void SetInventory(Dictionary<int, List<Item>> _items)
    {
        items.Clear();
        items = _items;
    }
}
