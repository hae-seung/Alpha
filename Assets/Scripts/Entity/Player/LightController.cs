using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput; // PlayerInput 참조

    void Update()
    {
        Vector2 direction = playerInput.MoveDirection;

        // 이동 방향에 따른 각도 설정
        if (direction == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // 위쪽 (0도)
        }
        else if (direction == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90); // 오른쪽 (-90도)
        }
        else if (direction == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180); // 아래쪽 (-180도)
        }
        else if (direction == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0, 0, -270); // 왼쪽 (-270도)
        }
    }
}
