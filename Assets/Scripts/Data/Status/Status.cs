using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    #region 데이터값
    
    public int MaxHp { get; private set; }
    public int Hp { get;  private set; }
    public int MaxMana { get; private set; }
    public int Mana { get; private set; }
    public int Str { get; private set; }
    public int Dex { get;  private set; }
    public int Intelligence { get; private set; }
    public int ThoughtPower { get; private set; }
    public int Defense { get;  private set; }
    
    #endregion
    
    public Status(StatusData data)//생성자
    {
        MaxHp = data.MaxHp;
        Hp = MaxHp;
        MaxMana = data.MaxMana;
        Mana = MaxMana;
        Str = data.Str;
        Dex = data.Dex;
        Intelligence = data.Intelligence;
        ThoughtPower = data.ThoughtPower;
        Defense = data.Defense;
    }

    public Status(Status status)//복사 생성자
    {
        MaxHp = status.MaxHp;
        Hp = status.Hp;
        MaxMana = status.MaxMana;
        Mana = status.Mana;
        Str = status.Str;
        Dex = status.Dex;
        Intelligence = status.Intelligence;
        ThoughtPower = status.ThoughtPower;
        Defense = status.Defense;
    }
    
    //todo: 스탯 변동사항들 정리하기

    public void OnDamage()
    {
        
    }
}
