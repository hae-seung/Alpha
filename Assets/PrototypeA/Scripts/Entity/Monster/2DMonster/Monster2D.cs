using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    [SerializeField] private GameObject monster3DPrefab; 
    [SerializeField] private MonsterCongnize monsterCongnize;
    private Status status;//필드 위에서 처형?을 위해 초기화 스텟이 필요함
    
    public MonsterMovement monsterMovement;
    public string MonsterName => monster3DPrefab.name;
    
    
    public bool IsLighted { get; private set; }//플레이어에게 손전등으로 들켯을 때
    public bool IsFindTarget => monsterCongnize.IsFindTarget;
    
    
    private void Awake()
    {
        IsLighted = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("플레이어 조우");
            if (IsFindTarget)//플레이어를 급습
            {
                PlayerManager.Instance.SetBattleMonsterData(this);
            }
            else if (IsLighted) //플레이어에게 피습
            {
                PlayerManager.Instance.SetBattleMonsterData(this);
            }
        }
    }

    public void LightMonster(bool state)//플레이어에게 발각된 경우
    {
        IsLighted = state;
    }
}