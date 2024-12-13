using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    [SerializeField] private MonsterData monsterData; //이걸 전투씬에 넘기면 됨
    [SerializeField] private MonsterCongnize monsterCongnize;
    private Status status;//필드 위에서 처형?을 위해 초기화 스텟이 필요함
    
    public MonsterMovement monsterMovement;
    
    public bool IsLighted { get; private set; }//플레이어에게 손전등으로 들켯을 때
    public bool IsFindTarget => monsterCongnize.IsFindTarget;
    public MonsterData GetMonsterData => monsterData;
    
    
    private void Awake()
    {
        IsLighted = false;
        status = new Status(monsterData.statusData);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("플레이어 조우");
            if (IsFindTarget)//급습처리
            {
                PlayerManager.Instance.SetBattleMonsterData(monsterData);
            }
            else if (IsLighted) //피습처리
            {
                PlayerManager.Instance.SetBattleMonsterData(monsterData);
            }
        }
    }

    public void LightMonster(bool state)//플레이어에게 발각된 경우
    {
        IsLighted = state;
    }
}