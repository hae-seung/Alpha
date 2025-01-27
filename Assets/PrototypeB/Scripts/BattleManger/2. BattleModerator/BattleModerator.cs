using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BattleModerator : MonoBehaviour
{
    private GameData receivedData;
    private TurnPreview _TurnPreview;

    PriorityQueue PQ = new PriorityQueue();

    public int TP_Counter;

    public Entity _DummyEntity;

    void Start()
    {
        receivedData = GameObject.Find("GameData").GetComponent<GameData>();
        gameObject.GetComponentInParent<Battle_Manager>().Initialize(this);
        TP_Counter = 0;

        _TurnPreview=GameObject.Find("TurnOrder").GetComponent<TurnPreview>();
    }

    public void Initialize()                                                                    // 세팅 준비.
    {                                                                                           // 이후 코루틴으로 턴 진행
        for (int i = 0; i < receivedData.StartTurn.Count; i++)
        {
            SetTurn(receivedData.StartTurn[i].GetComponent<Entity>());                          // CalculateStartTurn으로 정해진 턴 시작 순서에 맞춰 턴 분배
        }

        _TurnPreview.GetComponent<TurnPreview>().UpdatePreviewUI(PQ.PeekTopN(6));               // 턴 프리뷰 창에 순서 띄움.
        StartCoroutine(BattleTurnModerator());                                                  // 배틀 모더레이터 동작.
    }

    private IEnumerator BattleTurnModerator()                                                   // 0.4초마다 다음 턴에 해당하는 캐릭터에게 턴 부여
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

        if(activedEntity is DummyEntity)
        {
            Destroy(activedEntity);
        }
        else
        {
            activedEntity.TPCount = activedEntity.nextSkill.TP + TP_Counter;
            Debug.Log("현재 TP : " + TP_Counter);
            //Debug.Log("다음 공격의 TP는 : " + activedEntity.TPCount);

            PQ.Enqueue(activedEntity);                                              // 위의 코루틴 종료시 우선순위 큐에 다음 행동 삽입
        }

        _TurnPreview.GetComponent<TurnPreview>().UpdatePreviewUI(PQ.PeekTopN(6));
        //Debug.Log("프라이어티 큐의 peek 값 : " + PQ.Peek().TPCount);
    }

    public IEnumerator ActiveSkillAndSetNext(Entity entity)
    {
        yield return StartCoroutine(entity.ActiveSkill());

        if (entity.nextSkill.IsDOTSkill)
        {
            for (int i = 0; i < entity.nextSkill.DOTSkill.DOT_Count; i++)
            {
                Entity Temp = Instantiate(_DummyEntity);
                Temp.TPCount = (entity.nextSkill.TP * i) + TP_Counter;
                Temp.nextSkill = entity.nextSkill.DOTSkill;
                PQ.Enqueue(Temp);
            }
        }

        yield return StartCoroutine(entity.GetTurn());
    }
}