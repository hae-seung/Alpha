using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldManager : MonoBehaviour
{
    public static FieldManager Instance;
    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private SceneLoader battleSceneLoader;
    [SerializeField] private Monster2D monster;//임시
    
    private List<Monster2D> monsters = new List<Monster2D>();
    private Dictionary<Monster2D, float> monsterDistancesBeforeMove = new Dictionary<Monster2D, float>();
    private int completedMonsterMoves = 0;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        monsters.Add(monster);//임시
    }

    private void Start()
    {
        StartCoroutine(FieldMoveTurn());
    }

    private IEnumerator FieldMoveTurn()
    {
        while (true)
        {
            //플레이어가 움직이기 전 몬스터와의 거리 저장
            SaveMonsterDistances();
            
            yield return StartCoroutine(MovePlayerTurn());
            yield return StartCoroutine(MoveMonsterTurn());
        }
    }

    private void SaveMonsterDistances()
    {
        monsterDistancesBeforeMove.Clear();
        foreach (var monster in monsters)
        {
            if (monster.IsFindTarget && monster.IsLighted)
            {
                float distance = CalculateDistanceToPlayer(monster);
                monsterDistancesBeforeMove[monster] = distance;
            }
        }
    }

    private IEnumerator MovePlayerTurn()
    {
        playerInput.SetMovable(true);
        yield return new WaitUntil(() => playerMovement.HasMoved);
        playerMovement.HasMoved = false;
    }

   
    private IEnumerator MoveMonsterTurn()
    {
        UpdateBattleMonsterList();
        
        completedMonsterMoves = 0; // 초기화
        
        // 몬스터 이동
        MoveMonsters();

        // 모든 몬스터 이동 완료 대기
        yield return new WaitUntil(() => completedMonsterMoves == monsters.Count);
        //Debug.Log("모든 몬스터가 이동을 완료했습니다.");
    }
    
    private void UpdateBattleMonsterList()
    {
        //Debug.Log("MonsterList 업데이트 호출");
        foreach (var monster in monsters)
        {
            if (monsterDistancesBeforeMove.ContainsKey(monster) && monster.IsFindTarget && monster.IsLighted)
            {
                float preDistance = monsterDistancesBeforeMove[monster];
                float curDistance = CalculateDistanceToPlayer(monster);

                if (curDistance < preDistance) // 이전 턴보다 거리가 가까워진 경우
                {
                    //ebug.Log($"리스트에 {monster.name} 추가!");
                    PlayerManager.Instance.SetBattleMonsterData(monster);
                }
            }
        }
        CheckPlayerManagerMonsterList();
    }
    private void MoveMonsters()
    {
        foreach (var monster in monsters)
        {
            //Debug.Log("몬스터 이동 호출");
            monster.monsterMovement.Move(() => completedMonsterMoves++);
        }
    }

    private void CheckPlayerManagerMonsterList()
    {
        if (!PlayerManager.Instance.isEmptyMonsterData())
        {
            EnterBattleScene();
        }
    }

    private void EnterBattleScene()
    {
        battleSceneLoader.EnterScene("PrototypeB/Scenes/PrototypeB_Combat");
    }

    private float CalculateDistanceToPlayer(Monster2D monster)
    {
        return Vector2.Distance(monster.transform.position, playerMovement.transform.position);
    }

    public void AddNewMonster(Monster2D monster)
    {
        monsters.Add(monster);
    }
}