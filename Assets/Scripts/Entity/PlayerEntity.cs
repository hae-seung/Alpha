using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
   public List<Skill> skills;
   //public List<Item> items;
   
   public void SetUpPlayer(Character data)
   {
      status = new Status(data.status);//LivingEntity의 스테이터스 초기화
      skills = new List<Skill>(data.ownedSkill.Values);//딕셔너리를 리스트로 변환
      Debug.Log(skills[0].skillData.Name);
   }
   
   
   
}
