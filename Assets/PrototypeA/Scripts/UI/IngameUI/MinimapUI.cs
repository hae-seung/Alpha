using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{
    private RectTransform minimapRect;
    
    [Header("미니맵 사이즈")]
    private float defaultWidth;
    private float defaultHeight;

    [Header("미니맵 확대")] 
    private float defaultOrthographicSize = 5.0f;
    [SerializeField] private Camera minimapCamera;
    
    private Option optionInstance;
    
    private void Awake()
    {
        minimapRect = GetComponent<RectTransform>();
        defaultWidth = minimapRect.rect.width;
        defaultHeight = minimapRect.rect.height;
    }

    private void Start()
    {
        SettingManager.Instance.OnApply += OnMinimapOptionChanged;
        optionInstance = SettingManager.Instance.GetOptionInstance();
        InitMinimap();
    }

    private void InitMinimap()
    {
        if (optionInstance == null) return;

        SetMinimapSize();
        SetMinimapEnlarge();
    }

    private void SetMinimapEnlarge()
    {
        minimapCamera.orthographicSize = defaultOrthographicSize / optionInstance.MinimapEnlarge;
    }

    private void SetMinimapSize()
    {
        float newWidth = defaultWidth * optionInstance.MinimapSize;
        float newHeight = defaultHeight * optionInstance.MinimapSize;
        
        minimapRect.sizeDelta = new Vector2(newWidth, newHeight);
    }

    private void OnMinimapOptionChanged()
    {
        if (optionInstance == null) return; 
        SetMinimapSize();
        SetMinimapEnlarge();
    }
}
