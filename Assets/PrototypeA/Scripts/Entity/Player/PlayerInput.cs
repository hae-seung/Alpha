using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    public Vector2 MoveDirection { get; private set; }
    private bool isMovable = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isMovable = false;
            inventoryUI.ActiveInventory();
        }
        
        if (isMovable)
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

            Vector2 direction = new Vector2(horizontal, vertical).normalized;

            if (direction != Vector2.zero)
            {
                MoveDirection = direction;
                isMovable = false; // 입력을 막음
            }
        }
    }

    public void SetMovable(bool state)
    {
        isMovable = state;
    }

    public void ResetMoveDriection()
    {
        MoveDirection = Vector2.zero; // 입력 방향 초기화
    }
}