using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public static FieldManager Instance;
    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Monster2D monster;
    
    private List<Monster2D> monsters = new List<Monster2D>();
    private int completedMonsterMoves = 0;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        monsters.Add(monster);
    }

    private void Start()
    {
        StartCoroutine(FieldMoveTurn());
    }

    private IEnumerator FieldMoveTurn()
    {
        int count = 0;
        while (true)
        {
            count++;
            Debug.Log("새턴시작 : " + count);
            
            yield return StartCoroutine(MovePlayerTurn());
            yield return StartCoroutine(MoveMonsterTurn());
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
        Debug.Log("몬스터 턴 시작");
        completedMonsterMoves = 0; // 초기화
        
        // 1. 전투 리스트 업데이트
        UpdateBattleMonsterList();

        // 2. 몬스터 이동
        MoveMonsters();

        // 3. 모든 몬스터 이동 완료 대기
        yield return new WaitUntil(() => completedMonsterMoves == monsters.Count);
        Debug.Log("모든 몬스터가 이동을 완료했습니다.");
    }

    private void UpdateBattleMonsterList()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].IsFindTarget && monsters[i].IsLighted)
            {
                float preDistance = monsters[i].monsterMovement.DistanceToPlayer;
                monsters[i].monsterMovement.CalculateDistanceToPlayer();
                float curDistance = monsters[i].monsterMovement.DistanceToPlayer;

                if (curDistance < preDistance)
                {
                    Debug.Log("리스트에" + i + "번째 몬스터 추가!");
                    PlayerManager.Instance.SetBattleMonsterData(monsters[i].GetMonsterData);
                }
            }
        }
        CheckPlayerManagerMonsterList();
    }

    private void MoveMonsters()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            Debug.Log("무브를 호출합니다");
            monsters[i].monsterMovement.Move(() => completedMonsterMoves++);
        }
        CheckPlayerManagerMonsterList();
    }

    private void CheckPlayerManagerMonsterList()
    {
        if (!PlayerManager.Instance.isEmptyMonsterData())
        {
            GameManager.Instance.EnterBattleScene();
        }
    }

    public void AddNewMonster(Monster2D monster)
    {
        monsters.Add(monster);
    }
}
