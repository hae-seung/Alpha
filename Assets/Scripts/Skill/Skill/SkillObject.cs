using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
   [SerializeField] private SkillData skillData;
   private Skill skill;
   
   private void Awake()
   {
        //skill = new(skillData);                                                                               // 2024/12/13 나영빈. 기존 스크립트 삭제로 오류 발생. 주석 처리
    }

    public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Player")
      {
         if(PlayerManager.Instance.AddSkill(skill))
            Destroy(gameObject);
      }
   }
}
