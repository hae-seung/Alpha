using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private MonsterCongnize monsterCongnize;
    [SerializeField] private Transform player;
    [SerializeField] private int tilePixelSize = 32;   // 타일의 픽셀 크기
    [SerializeField] private int pixelsPerUnit = 32;   // Pixel Per Unit
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask roadLayer;      // road 레이어 설정

    [SerializeField] private int maxTurn = 5;
    private int monsterTurn = 0;
    
    private float tileUnitSize = 0f;
    private Vector3 targetPosition = Vector3.zero;

    public float DistanceToPlayer { get; private set; }
    private Vector2 lastDirection = Vector2.zero; // 마지막 이동 방향을 저장할 변수

    private void Start()
    {
        targetPosition = transform.position;
        tileUnitSize = (float)tilePixelSize / pixelsPerUnit;
    }

    public void Move(Action onComplete)
    {
        //Debug.Log("무브호출!");
        if (monsterCongnize.IsFindTarget) // 플레이어를 찾은 상황이라면 플레이어쪽으로 이동
        {
            CalculateNextPosition();
        }
        else // 상하좌우 중 랜덤 택 1
        {
            GetNextRandomPosition();
        }
        StartCoroutine(MoveMonsterAndRecognize(onComplete));
    }

    private void CalculateNextPosition()
    {
        Vector2 monsterPosition = transform.position;
        Vector2 playerPosition = player.position;

        Vector2 primaryDirection = Vector2.zero;
        Vector2 secondaryDirection = Vector2.zero;

        // 우선순위 방향 계산
        if (Mathf.Abs(playerPosition.x - monsterPosition.x) > Mathf.Abs(playerPosition.y - monsterPosition.y))
        {
            primaryDirection = (playerPosition.x > monsterPosition.x) ? Vector2.right : Vector2.left;
            secondaryDirection = (playerPosition.y > monsterPosition.y) ? Vector2.up : Vector2.down;
        }
        else
        {
            primaryDirection = (playerPosition.y > monsterPosition.y) ? Vector2.up : Vector2.down;
            secondaryDirection = (playerPosition.x > monsterPosition.x) ? Vector2.right : Vector2.left;
        }

        // 주축 방향으로 레이캐스트를 쏴서 이동 가능한지 확인
        if (CanMoveToDirection(monsterPosition, primaryDirection))
        {
            targetPosition += new Vector3(primaryDirection.x * tileUnitSize, primaryDirection.y * tileUnitSize, 0);
            lastDirection = primaryDirection; // 이동한 방향을 기록
            //Debug.Log($"주축 방향으로 이동: {primaryDirection}");
        }
        // 부축 방향으로 레이캐스트를 쏴서 이동 가능한지 확인
        else if (CanMoveToDirection(monsterPosition, secondaryDirection))
        {
            targetPosition += new Vector3(secondaryDirection.x * tileUnitSize, secondaryDirection.y * tileUnitSize, 0);
            lastDirection = secondaryDirection; // 이동한 방향을 기록
            //Debug.Log($"부축 방향으로 이동: {secondaryDirection}");
        }
        // 주축, 부축 모두 불가능할 경우, 남은 방향으로 시도
        else
        {
            targetPosition = GetFallbackPosition(monsterPosition, primaryDirection, secondaryDirection);
        }
    }

    private bool CanMoveToDirection(Vector2 currentPosition, Vector2 direction)
    {
        // 타일 중심으로 이동할 목표 위치 계산
        Vector2 nextTilePosition = GetTileAlignedPosition(currentPosition + direction * tileUnitSize);

        // 레이캐스트를 목표 타일의 위치로 쏨
        RaycastHit2D hit = Physics2D.Raycast(nextTilePosition, Vector2.zero, 0f, roadLayer);
        Debug.DrawLine(currentPosition, nextTilePosition, Color.blue, 1f); // 디버그 라인

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Road"))
        {
           // Debug.Log($"이동 가능: {direction}, 타일: {hit.collider.name}, 레이어: {LayerMask.LayerToName(hit.collider.gameObject.layer)}");
            return true;
        }

        //Debug.LogWarning($"이동 불가: {direction}, 위치: {nextTilePosition}");
        return false;
    }

    private Vector3 GetFallbackPosition(Vector2 currentPosition, Vector2 primary, Vector2 secondary)
    {
        // 주축 및 부축 방향을 제외한 나머지 방향 설정
        Vector2[] fallbackDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        fallbackDirections = Array.FindAll(fallbackDirections, dir => dir != primary && dir != secondary);

        foreach (Vector2 direction in fallbackDirections)
        {
            if (CanMoveToDirection(currentPosition, direction))
            {
                Debug.Log($"대체 방향으로 이동: {direction}");
                lastDirection = direction; // 이동한 방향을 기록
                return currentPosition + direction * tileUnitSize;
            }
        }

        //Debug.LogWarning("모든 방향이 막혀 이동 불가.");
        return currentPosition; // 이동하지 않음
    }

    private Vector2 GetTileAlignedPosition(Vector2 position)
    {
        // 타일 중심으로 위치 보정
        float alignedX = Mathf.Round(position.x / tileUnitSize) * tileUnitSize;
        float alignedY = Mathf.Round(position.y / tileUnitSize) * tileUnitSize;
        return new Vector2(alignedX, alignedY);
    }

    private void GetNextRandomPosition()
{
    // 가능한 이동 방향을 설정 (상, 하, 좌, 우)
    Vector2[] possibleDirections = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    List<Vector2> validDirections = new List<Vector2>();

    // 유효한 방향만 리스트에 추가
    foreach (Vector2 direction in possibleDirections)
    {
        // 반대 방향이 아닌 경우만 추가 (이전 방향의 반대 방향은 제외)
        if (CanMoveToDirection(transform.position, direction) && direction != -lastDirection)
        {
            validDirections.Add(direction);
        }
    }

    // 유효한 방향이 있으면 그 방향으로 이동
    if (validDirections.Count > 0)
    {
        // 같은 방향으로 3번 이동했으면 lastDirection 초기화
        Vector2 chosenDirection = validDirections[Random.Range(0, validDirections.Count)];

        if (chosenDirection == lastDirection)
        {
            monsterTurn++;
        }
        else
        {
            monsterTurn = 0;  // 다른 방향으로 갔으면 카운트 초기화
        }

        // 3번 이동했다면 lastDirection 초기화하고 반대 방향으로 이동
        if (monsterTurn >= maxTurn)
        {
            Debug.Log("같은 방향으로 3번 이동하여 lastDirection 초기화.");
            monsterTurn = 0; // 초기화 후 카운트 다시 시작

            // 반대 방향으로 유효한 이동 방향 추가
            Vector2 oppositeDirection = -lastDirection; // lastDirection을 초기화한 후 반대 방향 설정
            validDirections.Add(oppositeDirection); // 반대 방향을 유효한 방향 목록에 추가
            chosenDirection = oppositeDirection;  // 반대 방향으로 설정
        }

        // 방향으로 이동
        targetPosition += new Vector3(chosenDirection.x * tileUnitSize, chosenDirection.y * tileUnitSize, 0);
        lastDirection = chosenDirection;  // 현재 방향을 기록
        //Debug.Log($"랜덤 방향으로 이동: {chosenDirection}");
    }
    else
    {
        // 길이 막혔을 때, 바로 반대 방향으로 돌아가도록 수정
        targetPosition = transform.position + new Vector3(-lastDirection.x * tileUnitSize, -lastDirection.y * tileUnitSize, 0);
        lastDirection = -lastDirection;  // 반대 방향으로 업데이트
        monsterTurn = 0;
        //Debug.Log($"길이 막혀서 이전 방향으로 돌아갑니다: {lastDirection}");
    }
}




    private IEnumerator MoveMonsterAndRecognize(Action onComplete)
    {
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        monsterCongnize.CongnizePlayer(); // 이동이 끝난 뒤 인식범위 재확인
        onComplete?.Invoke();
    }
}
