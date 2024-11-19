using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
   public StatusData playerStatusData;
   public GameObject battlePlayerPrefab;
   
   private Character player; //이걸 관리하면 데이터 변환 관리
   private List<MonsterData> battlelMonsterDatas = new List<MonsterData>();//배틀 진입하는 몬스터
   
   public Character Player => player;
   public event Action<Character> OnPlayerInitialized;


   protected override void Awake()
   {
      base.Awake();
      player = new Character(playerStatusData, battlePlayerPrefab);
   }
   
   private void Start()
   {
      OnPlayerInitialized?.Invoke(player);
   }
   
   
   public bool AddSkill(Skill newSkill)
   {
      if (player.ownedSkill.ContainsKey(newSkill.skillData.Id))
      {
         Debug.Log("이미 소유한 스킬");
         return false;
      }
      player.ownedSkill.Add(newSkill.skillData.Id, new Skill(newSkill.skillData));
      Debug.Log("스킬 획득");
      return true;
   }

   public void SetBattleMonsterData(MonsterData data)
   {
      battlelMonsterDatas.Add(data);
   }

  
   public List<MonsterData> GetMonsterDatas()
   {
      int count = Mathf.Min(battlelMonsterDatas.Count, 3);
      return battlelMonsterDatas.GetRange(0, count); // 0부터 count개만큼 반환
   }

   
   public bool isEmptyMonsterData()
   {
      return battlelMonsterDatas.Count == 0 ? true : false;
   }
}
