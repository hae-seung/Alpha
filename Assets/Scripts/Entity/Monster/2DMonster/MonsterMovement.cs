using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private MonsterCongnize monsterCongnize;
    [SerializeField] private Transform player;
    [SerializeField] private int tilePixelSize = 32;   // 타일의 픽셀 크기
    [SerializeField] private int pixelsPerUnit = 32;   // Pixel Per Unit
    [SerializeField] private float moveSpeed = 5f;
    
    private float tileUnitSize = 0f;
    private Vector3 targetPosition = Vector3.zero;
    
    public float DistanceToPlayer { get; private set; }


    private void Awake()
    {
        CalculateDistanceToPlayer();
    }

    private void Start()
    {
        targetPosition = transform.position;
        tileUnitSize = (float)tilePixelSize / pixelsPerUnit;
    }

    public void Move(Action onComplete)
    {
        Debug.Log("무브호출!");
        if (monsterCongnize.IsFindTarget)//플레이어를 찾은 상황이라면 플레이어쪽으로 이동
        {
           CalculateNextPosition();
        }
        else//상하좌우 중 랜덤 택 1
        {
            GetNextRandomPosition();
        }
        StartCoroutine(MoveMonsterAndRecognize(onComplete));
    }

    private void CalculateNextPosition()
    {
        Vector2 monsterPosition = transform.position;
        Vector2 playerPosition = player.position;

        Vector2 direction = Vector2.zero;

        float randomValue = Random.Range(0f, 1f);
        if (Random.value <= randomValue)
        {
            direction = (playerPosition.x > monsterPosition.x) ? Vector2.right : Vector2.left;
        }
        else
        {
            direction = (playerPosition.y > monsterPosition.y) ? Vector2.up : Vector2.down;
        }
        
        targetPosition += new Vector3(direction.x * tileUnitSize, direction.y * tileUnitSize, 0);
    }

    private void GetNextRandomPosition()
    {
        Vector2[] possibleDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right, Vector2.zero };
        Vector2 direction = possibleDirections[Random.Range(0, possibleDirections.Length)];

        targetPosition += new Vector3(direction.x * tileUnitSize, direction.y * tileUnitSize, 0);
    }

    private IEnumerator MoveMonsterAndRecognize(Action onComplete)
    {
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        monsterCongnize.CongnizePlayer();//이동이 끝난 뒤 인식범위 재확인
        
        if(monsterCongnize.IsFindTarget)
            CalculateDistanceToPlayer(); //플레이어와의 거리 계산
        
        onComplete?.Invoke();
    }
    
    public void CalculateDistanceToPlayer()
    {
        DistanceToPlayer = Vector2.Distance(transform.position, player.position);
    }
}