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

    public void Initialize()                                                    // �Լ� ȣ��� ���õ� ���� �Ͽ� ���� ������ ����.
    {                                                                           // ���� �ڷ�ƾ���� �� ����
        for (int i = 0; i < receivedData.StartTurn.Count; i++)
        {
            Skill newSkill = new Skill();
            newSkill.owner = receivedData.StartTurn[i];
            SetTurn(newSkill);
        }

        StartCoroutine(BattleTurnModerator());
    }

    private IEnumerator BattleTurnModerator()                                   // 0.4�ʸ��� ���� �Ͽ� �ش��ϴ� ĳ���Ϳ��� �� �ο�
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

        Debug.Log("����� TP �ð� : " + newSkill.TP);
        PQ.Enqueue(newSkill);
    }

    public void GetTurn()                                                       //��ų ���� �� ���� ��ų ����
    {
        Skill nowSkill= PQ.Dequeue();
        TP_Counter = nowSkill.TP;
        Debug.Log("���� TP �ð� : "+TP_Counter);

        // ��ų ���� �߰� �ʿ�

        if (nowSkill.owner== receivedData.player)                               //�� ��ų �켱 ���� ť�� �߰�
        {
            Debug.Log("�÷��̾� �� ���� : " + TP_Counter);

            CharacterSkill fireball = new CharacterSkill();
            fireball.STP = 12;

            Skill newSkill = new Skill();
            newSkill.owner = receivedData.player;
            newSkill.skill = fireball;

            SetTurn(newSkill);
            //Debug.Log("�÷��̾��� ���̾ ���� : " + TP_Counter);
        }
        else
        {
            Debug.Log("�� �� ���� : " + TP_Counter);

            CharacterSkill normalAttack = new CharacterSkill();
            normalAttack.STP = Random.Range(5,15);

            Skill newSkill = new Skill();
            newSkill.owner = nowSkill.owner;
            newSkill.skill = normalAttack;

            SetTurn(newSkill);
            //Debug.Log("���� �Ϲݰ��� ���� : " + TP_Counter);
            //Debug.Log("�ش� ������ STP : " + normalAttack.STP);
        }
    }
}

public class Skill
{
    public Character owner;
    public CharacterSkill skill=null;
    public int TP = 0;
}