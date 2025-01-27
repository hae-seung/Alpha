using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeaponObject : MonoBehaviour
{
    public MainWeaponItemData data;
    private MainWeaponItem item;
    private void Awake()
    {
        item = new MainWeaponItem(data);
    }
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            other.GetComponent<PlayerInventory>().AddItem(item);
        Destroy(gameObject);
    }
}
