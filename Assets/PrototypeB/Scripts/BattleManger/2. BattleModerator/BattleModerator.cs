using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BattleModerator : MonoBehaviour
{
    private GameData receivedData;

    PriorityQueue PQ = new PriorityQueue();

    public int TP_Counter;

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
            SetTurn(receivedData.StartTurn[i].GetComponent<Entity>());
        }

        StartCoroutine(BattleTurnModerator());
    }

    private IEnumerator BattleTurnModerator()                                   // 0.4초마다 다음 턴에 해당하는 캐릭터에게 턴 부여
    {
        while (true)
        {
            yield return StartCoroutine(GetTurn());
        }
    }

    public void SetTurn(Entity entity)
    {
        PQ.Enqueue(entity);
    }

    public IEnumerator GetTurn()                                                       //스킬 시전 후 다음 스킬 예약
    {
        Entity activedEntity= PQ.Dequeue();
        TP_Counter = activedEntity.TPCount;

        if (activedEntity.nextSkill != null)
        {
            yield return StartCoroutine(ActiveSkillAndSetNext(activedEntity));
        }
        else
        {
            //StartCoroutine(SetSkill(activedEntity));
        }

        activedEntity.TPCount= activedEntity.nextSkill.TP + TP_Counter;
        Debug.Log("현재 공격의 TP : " + TP_Counter);
        Debug.Log("다음 공격의 TP는 : " + activedEntity.TPCount);
        
        PQ.Enqueue(activedEntity);                                              // 위의 코루틴 종료시 우선순위 큐에 다음 행동 삽입
        Debug.Log("프라이어티 큐의 peek 값 : " + PQ.Peek().TPCount);
    }

    public IEnumerator ActiveSkillAndSetNext(Entity entity)
    {
        yield return StartCoroutine(entity.ActiveSkill());

        yield return StartCoroutine(entity.GetTurn());
    }

    /*
    public IEnumerator SetSkill(Entity entity)
    {
        yield return StartCoroutine(entity.GetTurn());

        SetTurn(entity);
    }
    */
}