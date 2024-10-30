using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "SO/SkillData", order = int.MaxValue)]
public class SkillData : ScriptableObject
{
   [SerializeField] private int id;
   [SerializeField] private string skillName;
   [SerializeField] private int damage;
   [SerializeField] private int rtp;
   [SerializeField] private int stp;

   public int Id => id;
   public string Name => skillName;
   public int Damage => damage;
   public int Rtp => rtp;
   public int Stp => stp;
}
