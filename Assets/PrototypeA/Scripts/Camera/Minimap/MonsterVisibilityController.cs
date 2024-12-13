using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MonsterVisibilityController : MonoBehaviour
{
    [SerializeField] private Light2D flashlight;  // 손전등 역할을 하는 Light2D 컴포넌트
    [SerializeField] private Transform playerTransform;  // 플레이어의 Transform
    [SerializeField] private LayerMask monsterLayer;  // 몬스터가 있는 레이어
    
    private float lightRadius;  // 손전등의 최대 거리
    private float lightAngleCosine; // 빛의 각도에 대한 코사인 값
    private float lightHalfAngle = 45f; // 반각 (총 90도 범위)

    private void Awake()
    {
        lightRadius = flashlight.pointLightOuterRadius;
        lightAngleCosine = Mathf.Cos(lightHalfAngle * Mathf.Deg2Rad);
    }

    private void Update()
    {
        Vector2 flashlightDirection = flashlight.transform.up;
        Collider2D[] hits = Physics2D.OverlapCircleAll(playerTransform.position, lightRadius, monsterLayer);

        foreach (var hit in hits)
        {
            MinimapIconController sr = hit.GetComponent<MinimapIconController>();
            if (sr == null) continue;

            Vector2 directionToMonster = (hit.transform.position - playerTransform.position).normalized;
            float dotProduct = Vector2.Dot(flashlightDirection, directionToMonster);

            bool isWithinLightCone = dotProduct >= lightAngleCosine;
            sr.RenderSprite(isWithinLightCone);
        }
    }

    #region 기즈모

    // private void OnDrawGizmos()
    // {
    //     if (!flashlight) return;
    //
    //     // 빛의 현재 방향을 up으로 변경
    //     Vector2 flashlightDirection = flashlight.transform.up;
    //     Vector3 origin = playerTransform.position;
    //
    //     // 기본 원뿔 색상 설정
    //     Gizmos.color = Color.red;
    //
    //     // 빛의 양쪽 경계를 벡터로 계산
    //     Vector3 leftBoundary = Quaternion.Euler(0, 0, lightHalfAngle) * flashlightDirection * lightRadius;
    //     Vector3 rightBoundary = Quaternion.Euler(0, 0, -lightHalfAngle) * flashlightDirection * lightRadius;
    //
    //     // 원뿔을 이루는 양쪽 경계선 그리기
    //     Gizmos.DrawLine(origin, origin + leftBoundary);
    //     Gizmos.DrawLine(origin, origin + rightBoundary);
    //
    //     // 원뿔의 외곽을 이루는 호를 일정 간격으로 그림
    //     int segments = 20;
    //     float angleStep = lightHalfAngle * 2 / segments;
    //     Vector3 previousPoint = origin + rightBoundary;
    //     for (int i = 1; i <= segments; i++)
    //     {
    //         float angle = -lightHalfAngle + i * angleStep;
    //         Vector3 nextPoint = origin + (Quaternion.Euler(0, 0, angle) * flashlightDirection * lightRadius);
    //         Gizmos.DrawLine(previousPoint, nextPoint);
    //         previousPoint = nextPoint;
    //     }
    // }

    #endregion
    
}
