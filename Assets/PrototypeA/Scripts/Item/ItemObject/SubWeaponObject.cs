using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeaponObject : MonoBehaviour
{
    public SubWeaponItemData data;
    private SubWeaponItem item;
    private void Awake()
    {
        item = new SubWeaponItem(data);
    }
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            other.GetComponent<PlayerInventory>().AddItem(item);
        Destroy(gameObject);
    }
}
