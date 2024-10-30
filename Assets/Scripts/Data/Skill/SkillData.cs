using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : ScriptableObject
{
    [SerializeField] protected int id;
    [SerializeField] protected string skillName;
    [SerializeField] protected int rtp;
    [SerializeField] protected int stp;

    public int Id => id;
    public string Name => skillName;
    public int Rtp => rtp;
    public int Stp => stp;
}
