using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI; // 인벤토리 UI
    [SerializeField] private EscUI escUI;             // 설정창 UI

    private bool isInventoryOpen = false;
    private bool isSettingsOpen = false;

    private void Awake()
    {
        inventoryUI.ActiveInventory(isInventoryOpen);
        escUI.ToggleSettings(isSettingsOpen);
    }


    // 인벤토리 열기/닫기
    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.ActiveInventory(isInventoryOpen);

        if (isInventoryOpen)
        {
            CloseSettings(); // 설정창을 닫음 (동시에 열리지 않도록)
        }
    }

    public void CloseInventory()
    {
        isInventoryOpen = false;
        inventoryUI.ActiveInventory(false);
    }

    public bool IsInventoryOpen()
    {
        return isInventoryOpen;
    }

    // ESC 설정창 열기/닫기
    public void ToggleSettings()
    {
        isSettingsOpen = !isSettingsOpen;
        escUI.ToggleSettings(isSettingsOpen);

        if (isSettingsOpen)
        {
            CloseInventory(); // 인벤토리를 닫음 (동시에 열리지 않도록)
        }
    }

    public void CloseSettings()
    {
        isSettingsOpen = false;
        escUI.ToggleSettings(false);
    }

    public bool IsSettingsOpen()
    {
        return isSettingsOpen;
    }
}