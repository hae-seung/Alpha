using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleModerator : MonoBehaviour
{
    private GameData receivedData;

    PriorityQueue PQ = new PriorityQueue();

    int TP_Counter;

    void Start()
    {
        receivedData = GameObject.Find("GameData").GetComponent<GameData>();
        gameObject.GetComponentInParent<Battle_Manager>().Initialize(this);
        TP_Counter = 0;
    }

    public void Initialize()                                                    // 함수 호출시 세팅된 시작 턴에 맞춰 순서를 정함.
    {                                                                           // 이후 코루틴으로 턴 진행
        for (int i = 0; i < receivedData.StartTurn.Count; i++)
        {
            Skill newSkill = new Skill();
            newSkill.owner = receivedData.StartTurn[i];
            SetTurn(newSkill);
        }

        StartCoroutine(BattleTurnModerator());
    }

    private IEnumerator BattleTurnModerator()                                   // 0.4초마다 다음 턴에 해당하는 캐릭터에게 턴 부여
    {
        while (true)
        {
            GetTurn();

            yield return new WaitForSeconds(0.4f);
        }
    }

    public void SetTurn(Skill newSkill)
    {
        if(newSkill.skill!=null)
        {
            newSkill.TP = TP_Counter + newSkill.skill.STP;
        }
        else
        {
            newSkill.TP = TP_Counter;
        }

        Debug.Log("예약된 TP 시간 : " + newSkill.TP);
        PQ.Enqueue(newSkill);
    }

    public void GetTurn()                                                       //스킬 시전 후 다음 스킬 예약
    {
        Skill nowSkill= PQ.Dequeue();
        TP_Counter = nowSkill.TP;
        Debug.Log("현재 TP 시간 : "+TP_Counter);

        // 스킬 시전 추가 필요

        if (nowSkill.owner== receivedData.player)                               //고른 스킬 우선 순위 큐에 추가
        {
            Debug.Log("플레이어 턴 시작 : " + TP_Counter);

            CharacterSkill fireball = new CharacterSkill();
            fireball.STP = 12;

            Skill newSkill = new Skill();
            newSkill.owner = receivedData.player;
            newSkill.skill = fireball;

            SetTurn(newSkill);
            //Debug.Log("플레이어의 파이어볼 예약 : " + TP_Counter);
        }
        else
        {
            Debug.Log("적 턴 시작 : " + TP_Counter);

            CharacterSkill normalAttack = new CharacterSkill();
            normalAttack.STP = Random.Range(5,15);

            Skill newSkill = new Skill();
            newSkill.owner = nowSkill.owner;
            newSkill.skill = normalAttack;

            SetTurn(newSkill);
            //Debug.Log("적의 일반공격 예약 : " + TP_Counter);
            //Debug.Log("해당 공격의 STP : " + normalAttack.STP);
        }
    }
}

public class Skill
{
    public Character owner;
    public CharacterSkill skill=null;
    public int TP = 0;
}