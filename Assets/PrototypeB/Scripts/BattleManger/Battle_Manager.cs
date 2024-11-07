using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
    public BattleSetup battleSetup;
    public bool finSetup;
    public BattleModerator battleModerator;

    void Start()
    {
        battleSetup.TriggerSettingSystem();
        Invoke("StartBattleModerator", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(BattleSetup _battleSetup)
    {
        battleSetup = _battleSetup;
    }

    public void Initialize(BattleModerator _battleModerator)
    {
        battleModerator = _battleModerator;
    }

    public void StartBattleModerator()
    {
        battleModerator.Initialize();
    }
}
