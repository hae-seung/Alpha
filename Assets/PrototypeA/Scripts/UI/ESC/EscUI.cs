using System;
using UnityEngine;

public class EscUI : MonoBehaviour
{
    
    
    private void OnEnable()
    {
        
    }

    public void ToggleSettings(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}