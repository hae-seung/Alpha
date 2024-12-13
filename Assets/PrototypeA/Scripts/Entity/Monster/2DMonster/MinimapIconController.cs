using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconController : MonoBehaviour
{
   [SerializeField] private SpriteRenderer sr;
   [SerializeField] private Monster2D monster;
   
   public void RenderSprite(bool active)
   {
      sr.enabled = active;
      monster.LightMonster(active);
   }
   
   
}
