using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Btns : MonoBehaviour
{
    [Header("초기화")] 
    public TextMeshProUGUI curSelectBtn;
    public Image curSelectImage;
    public GameObject curOpenPanel;

    [Header("클릭시 변경되는 꼬다리 이미지")] 
    public Sprite normalImage;
    public Sprite selectImage;
    
    [Header("버튼 클리시 바뀌는 색상과 텍스트 사이즈")] 
    public Color32 normalColor;
    public Color32 selectColor;
    public int normalFontSize;
    public int selectFontSize;

    [Header("모든 판넬들")] 
    [Tooltip("curOpenPanel을 제외한 다른 판넬들을 끄기 위함")]
    public GameObject[] panels;
    
    
    
    private void Awake()
    {
        InitSetting();
    }

    public void OnSelectBtn(TextMeshProUGUI btn)
    {
        if (curSelectBtn == btn)
            return;
        SetBtn(btn);
    }
    

    public void OnOpenPanel(GameObject goalPanel)
    {
        if (curOpenPanel == goalPanel)
            return;
        OpenPanel(goalPanel);
    }

    public void OnChangeImage(Image image)
    {
        if (curSelectImage == image)
            return;
        SetImage(image);
    }
    

    private void InitSetting()
    {
        SetBtn(curSelectBtn);
        SetImage(curSelectImage);
        
        foreach (GameObject panel in panels)
        {
            if(panel == curOpenPanel)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }

    private void OpenPanel(GameObject panel)
    {
        curOpenPanel.SetActive(false);
        panel.SetActive(true);
        curOpenPanel = panel;
    }
    
    private void SetBtn(TextMeshProUGUI btn)
    {
        curSelectBtn.color = normalColor;
        curSelectBtn.fontSize = normalFontSize;

        curSelectBtn = btn;
        
        curSelectBtn.color = selectColor;
        curSelectBtn.fontSize = selectFontSize;
    }

    
    private void SetImage(Image image)
    {
        curSelectImage.sprite = normalImage;
        curSelectImage = image;
        curSelectImage.sprite = selectImage;
    }
    
}
