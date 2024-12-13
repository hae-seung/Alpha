using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int tilePixelSize = 32;   // 타일의 픽셀 크기
    [SerializeField] private int pixelsPerUnit = 32;   // Pixel Per Unit
    private float tileUnitSize = 0f;

    public bool HasMoved { get;  set; } // 이동 종료 여부 확인용

    private bool isMoving;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
        tileUnitSize = (float)tilePixelSize / pixelsPerUnit;
    }

    private void Update()
    {
        if (!isMoving && playerInput.MoveDirection != Vector2.zero)
        {
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        isMoving = true;

        // 목표 위치 설정
        targetPosition += new Vector3(
            playerInput.MoveDirection.x * tileUnitSize, 
            playerInput.MoveDirection.y * tileUnitSize, 
            0);

        // 목표 위치까지 이동
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition; // 정확히 목표 위치에 스냅

        // 이동 종료 처리
        isMoving = false;
        HasMoved = true;

        // 플레이어 입력 초기화
        playerInput.ResetMoveDriection();
    }
}