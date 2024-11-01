using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatusData", menuName = "SO/StatusData", order = int.MaxValue)]
public class StatusData : ScriptableObject
{
    [SerializeField] private int maxHp;
    //[SerializeField] private int hp;
    [SerializeField] private int maxMana;
    //[SerializeField] private int mana;
    [SerializeField] private int str;
    [SerializeField] private int dex;
    [SerializeField] private int intelligence;
    [SerializeField] private int thoughtPower;
    [SerializeField] private int defense;
    
    public int MaxHp => maxHp;
    //public int Hp => hp;
    public int MaxMana => maxMana;
    //public int Mana => mana;
    public int Str => str;
    public int Dex => dex;
    public int Intelligence => intelligence;
    public int ThoughtPower => thoughtPower;
    public int Defense => defense;
}
