using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopBtns : MonoBehaviour
{
    [Header("초기화")] 
    public TextMeshProUGUI curSelectBtn;
    public GameObject curOpenPanel;

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

    public void OnOpenPanel(GameObject goalPanel)
    {
        if (curOpenPanel == goalPanel)
            return;
        
        OpenPanel(goalPanel);
    }

    public void OnSelectBtn(TextMeshProUGUI btn)
    {
        if (curSelectBtn == btn)
            return;
        
        SetBtn(btn);
    }
    
    
    private void InitSetting()
    {
        SetBtn(curSelectBtn);
        foreach (GameObject panel in panels)
        {
            if(panel == curOpenPanel)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }

    private void OpenPanel(GameObject goalPanel)
    {
        curOpenPanel.SetActive(false);
        curOpenPanel = goalPanel;
        curOpenPanel.SetActive(true);
    }

    private void SetBtn(TextMeshProUGUI btn)
    {
        curSelectBtn.color = normalColor;
        curSelectBtn.fontSize = normalFontSize;

        curSelectBtn = btn;
        
        curSelectBtn.color = selectColor;
        curSelectBtn.fontSize = selectFontSize;
    }

    
}
