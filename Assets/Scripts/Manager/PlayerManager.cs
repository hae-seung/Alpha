using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
   public StatusData playerStatusData;
   
   [SerializeField]private Character player; //이걸 관리하면 데이터 변환 관리
   private MonsterData battleMonsterData;//배틀 진입하는 몬스터
   
   protected override void Awake()
   {
      base.Awake();
      player = new Character(playerStatusData);
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
      battleMonsterData = data;
   }

   public Character GetPlayer()
   {
      return player;
   }

   public MonsterData GetMonsterData()
   {
      return battleMonsterData;
   }
   
}
