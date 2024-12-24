using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopBtnSet : MonoBehaviour
{
    [Header("켜지면 디폴트로 보이는 화면 세팅")]
    public Button defaultBtn;
    public GameObject defaultTab;

    [Header("켜지면 초기화를 위한 모든 탭들")] 
    public List<GameObject> allTabs;
    
    
    
    
    private GameObject curOpenTab;

    private void OnEnable()
    {
        CloseAllTabs();
        
        curOpenTab = defaultTab;
        curOpenTab.SetActive(true);
        EventSystem.current.SetSelectedGameObject(defaultBtn.gameObject);
    }

    public void OnClickOpenTabBtn(GameObject openTab)
    {
        curOpenTab.SetActive(false);
        openTab.SetActive(true);
        curOpenTab = openTab;
    }

    private void CloseAllTabs()
    {
        foreach(var child in allTabs)
            child.SetActive(false);
    }
}
