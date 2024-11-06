using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int tilePixelSize = 32;   // 타일의 픽셀 크기
    [SerializeField] private int pixelsPerUnit = 32;   // Pixel Per Unit

    private bool isMoving;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
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

        // 타일의 픽셀 크기와 PPU에 따른 타일 유닛 크기를 계산
        float tileUnitSize = (float)tilePixelSize / pixelsPerUnit;

        // 목표 위치를 타일 유닛 크기 단위로 설정
        targetPosition += new Vector3(playerInput.MoveDirection.x * tileUnitSize, playerInput.MoveDirection.y * tileUnitSize, 0);

        // 목표 위치까지 이동
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition; // 정확히 목표 위치에 스냅
        isMoving = false;
    }
}