using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            vertical = 0;
        }
        else
        {
            horizontal = 0;
        }

        MoveDirection = new Vector2(horizontal, vertical).normalized;
        
    }
}