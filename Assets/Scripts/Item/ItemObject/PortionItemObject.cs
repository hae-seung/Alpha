using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionItemObject : MonoBehaviour
{
   public PortionItemData portionItemData;
   public Item item;
   private void Awake()
   {
      item = new PortionItem(portionItemData);
   }

   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         Debug.Log("획득");
         other.GetComponent<PlayerInventory>().AddItem(item);
         Destroy(gameObject);
      }
   }
}
