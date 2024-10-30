using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
   public SkillData skillData { get; private set; }

   public Skill(SkillData data) => skillData = data;

   public void UseSkill()
   {
      
   }
}
