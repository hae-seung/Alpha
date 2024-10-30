using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    [HideInInspector] public Character playerData;
    public MonsterData battleMonsterData;


    public Transform playerSpawnPoint;
    public Transform[] monsterSpawnPoint;
    private GameObject playerObject;
    private List<GameObject> monsterPrefab;
    
    private void Awake()
    {
        StartCoroutine(InitializeScene());
    }

    private IEnumerator InitializeScene()
    {
        yield return StartCoroutine(GetDataFromPostScene());   
        yield return StartCoroutine(CreateSceneEnvironment());  
        yield return StartCoroutine(CreateCharacter());  
    }

    private IEnumerator GetDataFromPostScene()
    {
        playerData = PlayerManager.Instance.GetPlayer();
        battleMonsterData = PlayerManager.Instance.GetMonsterData();
        yield return null;
    }

    private IEnumerator CreateSceneEnvironment()
    {
        yield return null;  // 대기 시간 없을 경우, null 사용
    }

    private IEnumerator CreateCharacter()
    {
        //플레이어 우선 생성
        playerObject = Instantiate(playerData.battleCharacterPrefab, playerSpawnPoint.position, Quaternion.identity);
        //3D 플레이어 데이터 셋업
        PlayerEntity playerEntity = playerObject.GetComponent<PlayerEntity>();
        playerEntity.SetUpPlayer(playerData);
        //몬스터 생성
        yield return null;
    }
    
}
