using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
   /*
  Character클래스로 관리
     현재 보유한 스킬List<Skill>
     현재 장착한 스킬List<Skill>

  현재 보유한 파티원 List<Character>
  Character에 들어갈 정보
     현재 보유한 스킬List<Skill>
     현재 장착한 스킬List<Skill>

  */
   
   public StatusData playerStatusData;
   
   public Character player; //이걸 관리하면 데이터 변환 관리

   public List<Character> partyList = new List<Character>();
   public List<Character> competeParty= new List<Character>();
   
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
   
}
