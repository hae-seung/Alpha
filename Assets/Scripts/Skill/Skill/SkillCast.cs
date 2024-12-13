using UnityEngine;

public class SkillCast
{
    public LivingEntity Caster { get; private set; }
    public LivingEntity Target { get; private set; }
    public Skill Skill { get; private set; }
    public int ExecuteTp { get; private set; }  // 스킬 발동 시점 (현재 TP + 최종 TP)

    public SkillCast(LivingEntity caster, LivingEntity target, Skill skill, int currentTp)
    {
        Caster = caster;
        Target = target;
        Skill = skill;
        ExecuteTp = currentTp + GetTp();  // 최종 TP 계산하여 발동 시점 설정
    }

    private int GetTp()  // 최종 TP 계산
    {
        /*                                                                                                                      // 2024/12/13 나영빈. 기존 스크립트 삭제로 오류 발생. 주석 처리
        int skillRtp = Skill.skillData.Rtp;
        int skillStp = Skill.skillData.Stp;
        int dex = Caster.Status.GetStat(StatType.Dex);

        float dexPercent = dex / 100f;
        
        float calculatedTp = (skillRtp * (1 - dexPercent)) + (skillStp + (1-dexPercent));
        
        
        return Mathf.RoundToInt(calculatedTp);  // 소수점 반올림하여 최종 TP 반환
        */
        return 1;
    }

    public void UseSkill()
    {
        //Skill.UseSkill(Caster, Target);                                                                                       // 2024/12/13 나영빈. 기존 스크립트 삭제로 오류 발생. 주석 처리
    }
}