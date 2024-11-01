using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    protected Status status;
    protected List<Skill> skills;
    //protected List<item> items;
    
    public event Action OnDeath;//사망 이벤트

    public Status Status => status;
    public List<Skill> Skills => skills;
    
    #region 전투스텟 데이터

    public int MaxHp { get; protected set; }
    public int Hp { get;  protected set; }
    public int MaxMana { get; protected set; }
    public int Mana { get; protected set; }
    public int Str { get; protected set; }
    public int Dex { get;  protected set; }
    public int Intelligence { get; protected set; }
    public int ThoughtPower { get; protected set; }
    public int Defense { get;  protected set; }

    #endregion
    
    
    protected void SetStauts()
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
    
    
    public virtual void OnDamage()
    {
       
    }

    
}
