using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public StatusData playerStatusData;
    public GameObject battlePlayerPrefab;
   
   
    private List<MonsterData> battlelMonsterDatas = new List<MonsterData>();//배틀 진입하는 몬스터
    public Inventory inventory;
    

    protected override void Awake()
    {
        base.Awake();
        inventory = new Inventory();
    }
    
   
    public bool AddSkill(Skill newSkill)
    {
        
        return true;
    }

    public void SetBattleMonsterData(MonsterData data)
    {
        battlelMonsterDatas.Add(data);
    }
   

   
    public bool isEmptyMonsterData()
    {
        return battlelMonsterDatas.Count == 0 ? true : false;
    }
}