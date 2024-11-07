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

    public void Initialize()                                                    // �Լ� ȣ��� ���õ� ���� �Ͽ� ���� ������ ����.
    {                                                                           // ���� �ڷ�ƾ���� �� ����
        for (int i = 0; i < receivedData.StartTurn.Count; i++)
        {
            SetTurn(receivedData.StartTurn[i].GetComponent<Entity>());
        }

        StartCoroutine(BattleTurnModerator());
    }

    private IEnumerator BattleTurnModerator()                                   // 0.4�ʸ��� ���� �Ͽ� �ش��ϴ� ĳ���Ϳ��� �� �ο�
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

    public IEnumerator GetTurn()                                                       //��ų ���� �� ���� ��ų ����
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
        Debug.Log("���� ������ TP : " + TP_Counter);
        Debug.Log("���� ������ TP�� : " + activedEntity.TPCount);
        
        PQ.Enqueue(activedEntity);                                              // ���� �ڷ�ƾ ����� �켱���� ť�� ���� �ൿ ����
        Debug.Log("�����̾�Ƽ ť�� peek �� : " + PQ.Peek().TPCount);
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