using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelSetting : MonoBehaviour
{
   [Header("Manager")] 
   private SettingManager manager;
   private Option optionInstance;
   private bool isInitialized = false;
      
   [Header("General")] 
   public MinimapSetting minimapSize;
   public MinimapSetting minimapEnlarge;

   [Header("ApplyBtn")] 
   public TextMeshProUGUI applyBtn;
   public TextMeshProUGUI cancelBtn;
   private void Awake()
   {
      StartCoroutine(WaitForSettingManager());
   }

   private IEnumerator WaitForSettingManager()
   {
      // SettingManager의 초기화가 완료될 때까지 대기
      while (SettingManager.Instance == null || SettingManager.Instance.GetOptionInstance() == null)
      {
         yield return null;
      }
      
      manager = SettingManager.Instance;
      optionInstance = manager.GetOptionInstance();
      
      InitUI();
      SetUI();
      isInitialized = true;
   }

   private void OnEnable()
   {
      if (isInitialized)
         SetUI();
   }
  

   private void InitUI()//게임 첫 시작 후 초기화 작업
   {
      InitGeneralOption();
      InitGraphicOption();
      InitSoundOption();
      InitControlOption();
   }

   #region Init

   private void InitGeneralOption()
   {
      minimapSize.Init(optionInstance.MinimapSize);
      minimapEnlarge.Init(optionInstance.MinimapEnlarge);
   }
   private void InitGraphicOption()
   {
      
   }
   private void InitSoundOption()
   {
      
   }
   private void InitControlOption()
   {
      
   }

   #endregion
   
   
   private void SetUI()//켜질때마다 로컬에 저장된 값 불러오기
   {
      SetGeneralOption();
      SetGraphicOption();
      SetSoundOption();
      SetControlOption();
   }
   
   #region SetUI

   private void SetGeneralOption()
   {
      minimapSize.Load(optionInstance.MinimapSize);
      minimapEnlarge.Load(optionInstance.MinimapEnlarge);
   }
   private void SetGraphicOption()
   {
      
   }
   private void SetSoundOption()
   {
      
   }
   private void SetControlOption()
   {
      
   }

   #endregion


   public void OnClickApplyBtn()
   {
      SaveData();
      manager.InvokeOnApply();
   }

   private void SaveData()//인스턴스에 값 저장
   {
      SaveGeneralData();
      //SaveGraphicData();
      //SaveSoundData();
      //SaveControlData();
   }

   #region Save

   private void SaveGeneralData()
   {
      optionInstance.MinimapSize = minimapSize.slider.value;
      optionInstance.MinimapEnlarge = minimapEnlarge.slider.value;
   }

   #endregion
   
}

[Serializable]
public class MinimapSetting
{
   public TextMeshProUGUI valueText;
   public Slider slider;

   public void Init(float value)
   {
      slider.onValueChanged.AddListener(OnChangedSliderValue);
      UpdateText(value);
      slider.value = value;
   }
   public void Load(float value)
   {
      UpdateText(value);
      slider.value = value;
   }
   public void OnChangedSliderValue(float value)
   {
      float roundedValue = Mathf.Round(value * 10f) / 10f;
      roundedValue = float.Parse(roundedValue.ToString("F1"));
      slider.value = roundedValue;
      UpdateText(roundedValue);
   }
   private void UpdateText(float value)
   {
      valueText.text = value.ToString("F1");
   }
}