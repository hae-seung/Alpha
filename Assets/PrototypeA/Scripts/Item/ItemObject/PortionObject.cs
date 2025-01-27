using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionObject : MonoBehaviour
{
   public PortionItemData data;
   private PortionItem item;
   private void Awake()
   {
      item = new PortionItem(data);
   }
   
   public void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player")
         other.GetComponent<PlayerInventory>().AddItem(item);
      Destroy(gameObject);
   }
}
