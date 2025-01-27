using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    public Vector2 MoveDirection { get; private set; }
    private bool isMovable = true;

    private void Update()
    {
        HandleUIInput();
        
        if (isMovable)
        {
            HandleMovementInput();
        }
    }

    // UI 입력 처리 (ESC 및 인벤토리 키)
    private void HandleUIInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            uiManager.ToggleInventory();
            SetMovable(!uiManager.IsInventoryOpen());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiManager.IsInventoryOpen())
            {
                uiManager.CloseInventory();
                SetMovable(true);
            }
            else if (uiManager.IsSettingsOpen())
            {
                uiManager.CloseSettings();
                SetMovable(true);
            }
            else
            {
                uiManager.ToggleSettings();
                SetMovable(!uiManager.IsSettingsOpen());
            }

            return;
        }
    }

    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 상하/좌우 하나의 방향만 입력 허용
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            vertical = 0;
        else
            horizontal = 0;

        Vector2 direction = new Vector2(horizontal, vertical).normalized;

        if (direction != Vector2.zero)
        {
            MoveDirection = direction;
            isMovable = false; // 입력을 막음
        }
    }

    public void SetMovable(bool state)
    {
        isMovable = state;
    }

    public void ResetMoveDirection()
    {
        MoveDirection = Vector2.zero; // 입력 방향 초기화
    }
}