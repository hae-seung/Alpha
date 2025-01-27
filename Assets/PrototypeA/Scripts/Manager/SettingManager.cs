using System;
using UnityEngine;

public class SettingManager : Singleton<SettingManager>
{
    private Option optionInstance;
    public event Action OnApply;

    protected override void Awake()//게임이 시작될때
    {
        base.Awake();
        optionInstance = new Option();
        optionInstance.Load();
    }

    public void InvokeOnApply()
    {
        optionInstance.Save();
        OnApply?.Invoke();
    }

    public Option GetOptionInstance()
    {
        return optionInstance;
    }
}

public class Option
{
    //General
    public float MinimapSize { get; set; }
    public float MinimapEnlarge { get; set; }
    
    //Graphics
    
    //Sound
    
    //Control

    public void Save()//로컬에 저장
    {
        SaveGeneralOption();
        //SaveGraphicOption();
        //SaveSoundOption();
        //SaveControlOption();
        PlayerPrefs.Save();
    }

    #region Save

    private void SaveGeneralOption()
    {
        PlayerPrefs.SetFloat("MinimapSize", MinimapSize);
        PlayerPrefs.SetFloat("MinimapEnlarge", MinimapEnlarge);
    }

    #endregion
   

    public void Load()//로컬에서 값 가져오기
    {
        LoadGeneralOption();
        // LoadGraphicOption();
        // LoadSoundOption();
        // LoadControlOption();
    }

    #region Load

    private void LoadGeneralOption()
    {
        MinimapSize = PlayerPrefs.HasKey("MinimapSize") ? PlayerPrefs.GetFloat("MinimapSize") : 1.0f;
        MinimapEnlarge = PlayerPrefs.HasKey("MinimapEnlarge") ? PlayerPrefs.GetFloat("MinimapEnlarge") : 1.0f;
    }

    #endregion
}