using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2D : MonoBehaviour
{
    public MonsterData monsterData; //이걸 전투씬에 넘기면 됨
    
    //스텟만 초기화
    private Status status;//필드 위에서 처형?을 위해 초기화 스텟이 필요함
    
    private void Awake()
    {
        status = new Status(monsterData.statusData);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("플레이어 조우");
            //todo: 씬 전환 하고 정보 넘기기. 어디에?
            PlayerManager.Instance.SetBattleMonsterData(monsterData);
            GameManager.Instance.EnterBattleScene();
        }
    }
}
