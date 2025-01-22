using System;
using System.Collections.Generic;
using UnityEngine;

public class EscUI : MonoBehaviour
{
    public Transform parentTab;
    private void OnEnable()
    {
        
    }

    public void ToggleSettings(bool isActive)
    {
        for (int i = 0; i < parentTab.childCount; i++)
            parentTab.GetChild(i).gameObject.SetActive(false);
        
        gameObject.SetActive(isActive);
    }
}