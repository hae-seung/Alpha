using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
   public void SetUpPlayer(Character data)
   {
      status = new Status(data.status);//LivingEntity의 스테이터스 복사 생성
      base.SetStauts();
      skills = new List<Skill>(data.ownedSkill.Values);//딕셔너리를 리스트로 변환
      //items = new()...;
   }

   // public override Skill SelectSkill()
   // {
   //    
   // }
   
}
