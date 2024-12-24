using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopBtnSet : MonoBehaviour
{
    [Header("������ ����Ʈ�� ���̴� ȭ�� ����")]
    public Button defaultBtn;
    public GameObject defaultTab;

    [Header("������ �ʱ�ȭ�� ���� ��� �ǵ�")] 
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
