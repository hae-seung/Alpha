using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
   [SerializeField] private bool x, y;
   [SerializeField] private Transform target;

   private void Update()
   {
      if (!target)
         return;
      
      transform.position = new Vector3(
         (x ? target.position.x : transform.position.x),
         (y ? target.position.y : transform.position.y),
         (transform.position.z));
   }
}
