using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도

    private Rigidbody2D rb;
    private PlayerInput playerInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        // 플레이어의 이동 방향을 받아 이동 처리
        Vector2 movement = playerInput.MoveDirection * moveSpeed;
        rb.velocity = movement;
    }
}
