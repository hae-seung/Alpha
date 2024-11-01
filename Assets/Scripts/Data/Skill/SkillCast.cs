using UnityEngine;

public class SkillCast
{
    public LivingEntity Caster { get; private set; }
    public Skill Skill { get; private set; }
    public int ExecuteTp { get; private set; }  // 스킬 발동 시점 (현재 TP + 최종 TP)

    public SkillCast(LivingEntity caster, Skill skill, int currentTp)
    {
        Caster = caster;
        Skill = skill;
        ExecuteTp = currentTp + GetTp();  // 최종 TP 계산하여 발동 시점 설정
    }

    private int GetTp()  // 최종 TP 계산
    {
        int skillRtp = Skill.skillData.Rtp;
        int skillStp = Skill.skillData.Stp;
        int dex = Caster.Status.Dex;

        float dexPercent = dex / 100f;
        float calculatedTp = (skillRtp * dexPercent) + (skillStp + dexPercent);
        return Mathf.RoundToInt(calculatedTp);  // 소수점 반올림하여 최종 TP 반환
    }
}