using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MonsterVisibilityController : MonoBehaviour
{
    [SerializeField] private Light2D flashlight;  // 손전등 역할을 하는 Light2D 컴포넌트
    [SerializeField] private Transform playerTransform;  // 손전등을 들고 있는 플레이어의 Transform
    [SerializeField] private LayerMask monsterLayer;  // 몬스터가 있는 레이어
    private float lightRadius;  // 손전등의 최대 거리
    private float lightHalfAngle = 45f; // 손전등이 비추는 반각 (총 90도)

    private void Awake()
    {
        lightRadius = flashlight.pointLightOuterRadius;
    }

    private void Update()
    {
        // 플레이어가 현재 바라보는 방향(절대 각도)
        float playerAngle = playerTransform.eulerAngles.z;

        // 손전등의 빛이 비추는 각도 범위 계산
        float minAngle = playerAngle - lightHalfAngle;
        float maxAngle = playerAngle + lightHalfAngle;

        // 손전등 빛의 범위 내에 있는 모든 몬스터 감지
        Collider2D[] hits = Physics2D.OverlapCircleAll(playerTransform.position, lightRadius, monsterLayer);

        foreach (var hit in hits)
        {
            MinimapIconController sr = hit.GetComponent<MinimapIconController>();
            if (sr == null) continue;

            // 몬스터와 손전등 위치 간의 벡터를 계산하여 절대 각도 구하기
            Vector2 directionToMonster = (hit.transform.position - playerTransform.position).normalized;
            float angleToMonster = Mathf.Atan2(directionToMonster.y, directionToMonster.x) * Mathf.Rad2Deg;

            // 각도를 0~360 범위로 맞춤
            if (angleToMonster < 0) angleToMonster += 360;
            if (minAngle < 0) minAngle += 360;
            if (maxAngle >= 360) maxAngle -= 360;

            // 손전등의 90도 범위 내에 있을 때만 스프라이트 활성화
            bool isWithinLightCone;
            if (minAngle < maxAngle)
            {
                isWithinLightCone = angleToMonster >= minAngle && angleToMonster <= maxAngle;
            }
            else
            {
                isWithinLightCone = angleToMonster >= minAngle || angleToMonster <= maxAngle;
            }

            sr.UnableRender(isWithinLightCone);
        }
    }
}
