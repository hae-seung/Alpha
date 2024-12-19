using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public StatusData playerStatusData;
    public GameObject battlePlayerPrefab;
   
    private List<string> battlelMonsterDatas = new List<string>();//배틀 진입하는 몬스터
    public Inventory inventory;
    
    
    protected override void Awake()
    {
        base.Awake();
        inventory = new Inventory();
    }
    

    public void SetBattleMonsterData(Monster2D monster)
    {
        battlelMonsterDatas.Add(monster.MonsterName);
    }

    public List<string> GetMonsterData()
    {
        return battlelMonsterDatas;
    }

   
    public bool isEmptyMonsterData()
    {
        return battlelMonsterDatas.Count == 0 ? true : false;
    }
}