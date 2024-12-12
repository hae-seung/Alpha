using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite icon;
    public string description;              // ��ų ����
    public GameObject effectPrefab;         // ����Ʈ ������
    public AnimationClip animation;         // ��ų �ִϸ��̼�

    public int damage;                      // ������ ��
    public float STR_Apply = 0;
    public float DEX_Apply = 0;
    public float INT_Apply = 0;
    public float LUCK_Apply = 0;

    public Entity owner;
    public CharacterSkill skill = null;
    public int TP = 0;

    public bool IsDOTSkill = false;
    public DOT_Skill DOTSkill;
}
