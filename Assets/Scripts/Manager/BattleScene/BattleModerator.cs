using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleModerator : MonoBehaviour
{
    private PlayerEntity player;
    private List<MonsterEntity> monsters = new List<MonsterEntity>();
    [SerializeField] private BattleUI battleUI;
    
    private PriorityQueue<SkillCast> skillQueue;
    private bool isSetUpFinished;
    private bool isTurnProgress;
    private int battleTp;

    private bool isPlayerSkillSelected; // 스킬 선택 완료 여부

    private void Awake()
    {
        skillQueue = new PriorityQueue<SkillCast>(new SkillComparer());
        isSetUpFinished = false;
        isTurnProgress = false;
    }


    private void Update()
    {
        if (!isSetUpFinished || isTurnProgress || skillQueue.IsEmpty())
            return;

        if (skillQueue.Peek().ExecuteTp > battleTp)
            battleTp++;
        else
        {
            isTurnProgress = true;
            StartCoroutine(BattleStart());
        }
    }

    private IEnumerator BattleStart()
    {
        Debug.Log("현재 TP" + battleTp);
        Debug.Log(skillQueue.Peek().Skill.skillData.Name + "발동!");
        skillQueue.Dequeue();
        isTurnProgress = false;
        yield return null;
    }
    
    public void RegisterEntity(PlayerEntity player, List<MonsterEntity> monsters)
    {
        this.player = player;
        this.monsters = monsters;
        StartCoroutine(SelectSkill());
    }

    private IEnumerator SelectSkill()
    {
        yield return StartCoroutine(SetMonsterSkill());
        yield return StartCoroutine(SetPlayerSkill());
        isSetUpFinished = true;
    }
    
    private IEnumerator SetMonsterSkill()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            Skill selectSkill = monsters[i].SelectSkill();

            if (selectSkill == null)
                yield return null;

            SkillCast skillCast = new SkillCast(monsters[i],player ,selectSkill, battleTp);
            skillQueue.Enqueue(skillCast);
        }
        yield return null;
    }

    private IEnumerator SetPlayerSkill()
    {
        isPlayerSkillSelected = false;  // 스킬 선택 플래그 초기화
        battleUI.OpenUI();  // UI 열기

        // 플레이어가 스킬을 선택할 때까지 대기
        yield return new WaitUntil(() => isPlayerSkillSelected);
    }

    public void OnPlayerSkillSelected(Skill selectedSkill)
    {
        SkillCast skillCast = new SkillCast(player,monsters[0],selectedSkill, battleTp);
        skillQueue.Enqueue(skillCast);
        
        battleUI.OpenUI();
        isPlayerSkillSelected = true;  // 스킬 선택 완료 설정
        
        Debug.Log(selectedSkill.skillData.Name);
    }
}