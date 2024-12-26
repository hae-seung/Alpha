using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonImage
{
   public Sprite[] images = new Sprite[2];
   //0번 : 기본 이미지 1번 : 선택 이미지
}


public class RegionBtn : MonoBehaviour
{
   [Header("초기화")] 
   public Image[] btns; //버튼 기능을 하는 이미지를 들고옴
   public GameObject curOpenPanel;

   [Header("다른 버튼 클릭시 변경되는 이미지")] 
   public List<ButtonImage> images;

   private Image curSelectBtn;
   private Sprite normalSprite;
   
   
   private void Awake()
   {
      InitSetting();
   }

   private void InitSetting()
   {
      curSelectBtn = btns[0];
      curSelectBtn.sprite = images[0].images[1];
      normalSprite = images[0].images[0];
   }

   public void OnClickBtn(int index)
   {
      curSelectBtn.sprite = normalSprite;
      curSelectBtn = btns[index];

      curSelectBtn.sprite = images[index].images[1];
      normalSprite = images[index].images[0];
   }

   public void OnClickBtn2(GameObject goalPanel)
   {
      OpenPanel(goalPanel);
   }

   private void OpenPanel(GameObject panel)
   {
      curOpenPanel.SetActive(false);
      panel.SetActive(true);
      curOpenPanel = panel;
   }
}
