using UnityEngine;

#region 스킬능력구현

public interface ISkillEffect
{
    void ApplyEffect(LivingEntity caster, LivingEntity target = null);
}

public abstract class SkillEffectSO : ScriptableObject, ISkillEffect
{
    public abstract void ApplyEffect(LivingEntity caster, LivingEntity target);
}

#endregion

#region 휘두르기스킬

[CreateAssetMenu(fileName = "SwingEffectSO", menuName = "SO/SkillEffect/SwingEffect")]
public class SwingEffectSO : SkillEffectSO
{
    [SerializeField] private int damage;

    public override void ApplyEffect(LivingEntity caster, LivingEntity target = null)
    {
        int finalDamage = caster.CalculateSkillDamage(damage);
        target.OnDamage(finalDamage);
    }
}

#endregion

#region 마구휘두르기 스킬

[CreateAssetMenu(fileName = "WildSwingEffectSO", menuName = "SO/SkillEffect/WildSwingEffect")]
public class WildSwingEffectSO : SkillEffectSO
{
    [SerializeField] private int damage;

    public override void ApplyEffect(LivingEntity caster, LivingEntity target = null)
    {
        int finalDamage = caster.CalculateSkillDamage(damage);
        target.OnDamage(finalDamage);
    }
}

#endregion

#region 하울링스킬

[CreateAssetMenu(fileName = "HowlingEffectSO", menuName = "SO/SkillEffect/HowlingEffect")]
public class HowlingEffectSO : SkillEffectSO
{
    [SerializeField] private int buffAmount;
    private BuffType buffType = BuffType.speed;
    public override void ApplyEffect(LivingEntity caster, LivingEntity target = null)
    {
       caster.ApplyBuffSkill(buffType, buffAmount);
    }
}

#endregion

#region 물어뜯기 스킬

[CreateAssetMenu(fileName = "BiteEffectSO", menuName = "SO/SkillEffect/BiteEffect")]
public class BiteEffectSO : SkillEffectSO
{
    [SerializeField] private int damage;

    public override void ApplyEffect(LivingEntity caster, LivingEntity target = null)
    {
        int finalDamage = caster.CalculateSkillDamage(damage);
        target.OnDamage(finalDamage);
    }
}

#endregion


public enum BuffType
{
    speed
}