using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSetup : MonoBehaviour
{
    private Character playerData;
    private MonsterData battleMonsterData;
    private BattleModerator battleModerator;
    [SerializeField] private BattleUI battleUI;
    
    private PlayerEntity playerEntity;
    private List<MonsterEntity> monsterEntities = new List<MonsterEntity>();
        
    [Header("SpawnPoint")]
    public Transform playerSpawnPoint;
    public Transform[] monsterSpawnPoint;
    
    private void Awake()
    {
        //todo: 로딩씬 띄우기
        battleModerator = GetComponent<BattleModerator>();
        StartCoroutine(InitializeScene());
    }
    
    private IEnumerator InitializeScene()
    {
        yield return StartCoroutine(GetDataFromPostScene());   
        yield return StartCoroutine(CreateSceneEnvironment());  
        yield return StartCoroutine(CreateCharacter());
        yield return StartCoroutine(SetUpUI());
        yield return StartCoroutine(RemoveBlackScreen());
        CallBattleModerator();
    }

    private void CallBattleModerator()
    {
        battleModerator.RegisterEntity(playerEntity, monsterEntities);
    }

    private IEnumerator RemoveBlackScreen()
    {
        //로딩씬 제거
        yield return null;
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
        GameObject playerObject = Instantiate(playerData.battleCharacterPrefab, 
            playerSpawnPoint.position, Quaternion.identity);
        //3D 플레이어 데이터 셋업
        playerEntity = playerObject.GetComponent<PlayerEntity>();
        playerEntity.SetUpPlayer(playerData);
        
        
        // 생성할 몬스터 데이터 리스트 준비 (자신과 파티 몬스터들 포함)
        List<MonsterData> allMonsters = new List<MonsterData> { battleMonsterData };
        allMonsters.AddRange(battleMonsterData.monsterPartyData);

        for (int i = 0; i < allMonsters.Count && i < monsterSpawnPoint.Length; i++)
        {
            GameObject monster = Instantiate(allMonsters[i].battleMonsterPrefab, 
                monsterSpawnPoint[i].position, 
                Quaternion.identity);
    
            MonsterEntity monsterEntity = monster.GetComponent<MonsterEntity>();
            monsterEntity.SetUpMonster(allMonsters[i]);
            monsterEntities.Add(monsterEntity);
        }
        
        yield return null;
    }

    private IEnumerator SetUpUI()
    {
        //버튼 및 기본 화면에 보일 것들 초기화
        battleUI.InitUI(playerEntity, battleModerator.OnPlayerSkillSelected);
        yield return null;
    }
    
}
