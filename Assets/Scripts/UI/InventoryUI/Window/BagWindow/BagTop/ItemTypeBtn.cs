using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemTypeBtn : MonoBehaviour
{
   [Header("버튼 클릭시 활성화 시킬 창")]
   public ItemTypeBtnSet buttonManager;
   public TextMeshProUGUI btnText;
   public GameObject bagItemList;

   public void onClickItemTypeBtn()
   {
      buttonManager.onClickItemType(btnText, bagItemList);
   }
}
