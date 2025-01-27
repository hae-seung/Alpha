using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorObject : MonoBehaviour
{
   public ArmorItemData data;

   private ArmorItem item;

   private void Awake()
   {
      item = new ArmorItem(data);
   }


   public void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player")
         other.GetComponent<PlayerInventory>().AddItem(item);
      Destroy(gameObject);
   }
}
