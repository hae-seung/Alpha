using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
   public Slider hpBar;
   public Button[] skillButtons;

   private LivingEntity playerEntity;
   
   private Action<Skill> onSkillSelected;
   private bool isOpenUI;

   private void Awake()
   {
      isOpenUI = false;
   }

   public void InitUI(LivingEntity playerEntity, Action<Skill> skillSelectCallback)//함수를 델리게이트인 Action으로 받음
   {
      // HP Bar 초기화
      this.playerEntity = playerEntity;
      hpBar.maxValue = playerEntity.Status.GetStat(StatType.MaxHp);
      hpBar.value = playerEntity.Status.GetStat(StatType.Hp);

      // 스킬 버튼 초기화 및 콜백 설정
      onSkillSelected = skillSelectCallback;

      for (int i = 0; i < playerEntity.Skills.Count; i++)
      {
         Skill skill = playerEntity.Skills[i];
         Text btnText = skillButtons[i].GetComponentInChildren<Text>();
         btnText.text = skill.skillData.Name;

         // 클릭 이벤트 등록 (현재 스킬을 콜백과 연결)
         int index = i;
         skillButtons[i].onClick.AddListener(() => onClickSkillBtn(playerEntity.Skills[index]));
      }
   }
   
   
   // 버튼 클릭 시 호출되어 선택된 스킬을 콜백으로 전달
   private void onClickSkillBtn(Skill selectedSkill)
   {
      onSkillSelected?.Invoke(selectedSkill);
   }

   public void OpenUI()
   {
      isOpenUI = !isOpenUI;
      gameObject.SetActive(isOpenUI);
   }

   public void UpdateSituation()
   {
      hpBar.value = playerEntity.Status.GetStat(StatType.Hp);
   }
   
}
