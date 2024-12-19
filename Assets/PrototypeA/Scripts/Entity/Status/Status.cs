using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    MaxHp,
    Hp,
    MaxMana,
    Mana,
    Str,
    Dex,
    Intelligence,
    ThoughtPower,
    Defense
}

public class Status
{
    private Dictionary<StatType, int> stats = new Dictionary<StatType, int>();
    
    public Status(StatusData data) // 생성자
    {
        stats[StatType.MaxHp] = data.MaxHp;
        stats[StatType.Hp] = data.MaxHp; // 초기 HP는 MaxHp와 동일
        stats[StatType.MaxMana] = data.MaxMana;
        stats[StatType.Mana] = data.MaxMana; // 초기 Mana는 MaxMana와 동일
        stats[StatType.Str] = data.Str;
        stats[StatType.Dex] = data.Dex;
        stats[StatType.Intelligence] = data.Intelligence;
        stats[StatType.ThoughtPower] = data.ThoughtPower;
        stats[StatType.Defense] = data.Defense;
    }

    public Status(Status status) // 복사 생성자
    {
        foreach (var stat in status.stats)
        {
            stats[stat.Key] = stat.Value;
        }
    }

    // 특정 스탯 값을 가져오기
    public int GetStat(StatType statType)
    {
        return stats.ContainsKey(statType) ? stats[statType] : 0;
    }
    
    //todo: 장비장착 and 전투시 스탯 변화 적용 로직

    public void ModifyStat(StatType statType, int amount)
    {
        if (stats.ContainsKey(statType))
        {
            stats[statType] += amount;
        }
    }
}
