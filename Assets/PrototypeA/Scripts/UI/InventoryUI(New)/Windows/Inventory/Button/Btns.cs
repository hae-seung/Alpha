using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Btns : MonoBehaviour
{
    [Header("초기화")] 
    public TextMeshProUGUI curSelectBtn;
    public GameObject curOpenPanel;

    [Header("폰트 사이즈")] 
    public int normalFontSize;
    public int selectFontSize;

    [Header("색상")] 
    public Color32 normalColor;
    public Color32 selectColor;
    
    private void Awake()
    {
        InitSetting();
    }

    public void OnClickBtn(TextMeshProUGUI self)
    {
        ChangeTextSize(self);
        ChangeBtnColor(self);
        curSelectBtn = self;
    }

    public void OnClickBtn2(GameObject goalPanel)
    {
        OpenPanel(goalPanel);
    }
    
    private void InitSetting()
    {
        curSelectBtn.color = selectColor;
        curSelectBtn.fontSize = selectFontSize;
        curOpenPanel.SetActive(true);
    }

    private void OpenPanel(GameObject panel)
    {
        curOpenPanel.SetActive(false);
        panel.SetActive(true);
        curOpenPanel = panel;
    }

    private void ChangeBtnColor(TextMeshProUGUI selectBtn)
    {
        curSelectBtn.color = normalColor;
        selectBtn.color = selectColor;
    }

    private void ChangeTextSize(TextMeshProUGUI selectBtn)
    {
        curSelectBtn.fontSize = normalFontSize;
        selectBtn.fontSize = selectFontSize;
    }
}
