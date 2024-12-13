using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    protected Status status;
    protected List<Skill> skills = new List<Skill>();
    //protected List<item> items;
    public event Action OnDeath;//사망 이벤트

    public Status Status => status;
    public List<Skill> Skills => skills;
    
    
    
    protected void SetStauts()
    {
        status = new Status(status);
    }
    
    
    public virtual void OnDamage(int damage)
    {
        int damageAmount = CalculateFinalSkillDamage(damage);
        status.ModifyStat(StatType.Hp, damage);
        if (status.GetStat(StatType.Hp) <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public int CalculateFinalSkillDamage(int damage)
    {
        //todo: 스텟 방어력에 따른 입을데미지의 최종 계산 공식 적용
        return damage;//임시
    }

    public int CalculateSkillDamage(int skillDamage)
    {
        //todo:스탯에 따른 스킬 데미지 계산 공식 적용
        return skillDamage;//임시
    }


    public void ApplyBuffSkill(BuffType buffType, int buffAmount)
    {
        StatType targetStat;
        switch (buffType)
        {
            case BuffType.speed:
                targetStat = StatType.Dex;
                break;
            default:
                Debug.LogWarning($"Buff type {buffType} is not supported.");
                return;
        }
        ModifyStat(targetStat, buffAmount);
    }

    private void ModifyStat(StatType targetStat, int buffAmount)
    {
        status.ModifyStat(targetStat, buffAmount);
    }
}
