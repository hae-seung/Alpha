using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum AccType
{
   Hat,
   Neck,
   Earring,
   Bracelet,
   Ring
}

public class AccItemData : EquipItemData
{
   [Header("악세서리 부위")]
   [SerializeField] private AccType accType;


   public AccType GetAccType()
   {
      return accType;
   }
}
