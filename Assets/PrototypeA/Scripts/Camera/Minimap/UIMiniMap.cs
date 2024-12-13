using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMiniMap : MonoBehaviour
{
   [SerializeField] private Camera minimapCamera;
   [SerializeField] private float zoomMin = 1f;
   [SerializeField] private float zoomMax = 30f;
   [SerializeField] private float zoomOneStep = 1f;
   [SerializeField] private Text textMapName;

   private void Awake()
   {
      textMapName.text = "위험지대";
   }

   public void ZoomIn()
   {
      minimapCamera.orthographicSize = Mathf.Max(minimapCamera.orthographicSize - zoomOneStep, zoomMin);
   }

   public void ZoomOut()
   {
      minimapCamera.orthographicSize = Mathf.Min(minimapCamera.orthographicSize + zoomOneStep, zoomMax);
   }
}
