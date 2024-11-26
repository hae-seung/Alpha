using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> items;
    
    
    private void Awake()
    {
        PlayerManager.Instance.OnPlayerInitialized += InitInventory;
    }
   

    private void InitInventory(Character player)
    {
        Debug.Log("첫 인벤토리 초기화 성공");
        items = new List<Item>(player.inventory.Items);
    }

    public void GetInventoryFromManager()
    {
        items = new List<Item>(PlayerManager.Instance.Player.inventory.Items);
    }

    public void SetInventoryToManager()
    {
        PlayerManager.Instance.Player.inventory.SetInventory(items);
    }
    
    
    
    
    
}