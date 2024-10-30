using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    #region 데이터값
    
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public int MaxMana { get; private set; }
    public int Mana { get; private set; }
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Intelligence { get; private set; }
    public int ThoughtPower { get; private set; }
    public int Defense { get; private set; }
    
    #endregion
    
    public Status(StatusData data)//생성자
    {
        MaxHp = data.MaxHp;
        Hp = MaxHp;
        MaxMana = data.MaxMana;
        Mana = MaxMana;
        Strength = data.Str;
        Dexterity = data.Dex;
        Intelligence = data.Intelligence;
        ThoughtPower = data.ThoughtPower;
        Defense = data.Defense;
    }
    
    
    //todo: 스탯 변동사항들 정리하기
}
