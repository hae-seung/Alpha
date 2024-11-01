using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEntity : LivingEntity
{
   
   
   
   
   
   
   public void SetUpMonster(MonsterData data)
   {
      status = new Status(data.statusData);//복사 생성자가 아닌 일반 생성자로 초기화
      base.SetStauts();
      
      for (int i = 0; i < data.skills.Count; i++)
      {
         Skill skill = new Skill(data.skills[i]);
         skills.Add(skill);
      }
      
      //items = new() ...;
   }


   public Skill SelectSkill()
   {
      #region 몬스터 스킬 구현전까지만 임시
      if (skills.Count == 0)
         return null;
      #endregion
      
      
      int num = Random.Range(0, skills.Count);
      Skill selectSkill = skills[num];
      
      return selectSkill;
   }
}
