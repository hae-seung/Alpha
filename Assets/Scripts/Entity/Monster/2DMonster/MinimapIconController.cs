using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconController : MonoBehaviour
{
   [SerializeField] private SpriteRenderer sr;
   

   public void UnableRender(bool active)
   {
      sr.enabled = active;
   }

  
}
