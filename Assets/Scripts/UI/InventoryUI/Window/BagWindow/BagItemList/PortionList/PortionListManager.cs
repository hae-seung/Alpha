using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortionListManager : MonoBehaviour
{
   [Header("아이템 슬롯묶음 관리자")]
   public ItemSlotManager hpList;
   public ItemSlotManager mpList;
   public void Classify(PortionItem newItem, int idx, int stackIdx)
   {
      StatType statType = newItem.GetStatType;
      switch (statType)
      {
         case StatType.Hp:
            //HP 관리자에게 넘겨줌
            Debug.Log("으앙");
            break;
         case StatType.Mana:
            //MP 관리자에게 넘겨줌
            Debug.Log("호옹");
            break;
         default:
            break;
      }
   }
}
