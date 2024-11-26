using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject[] inventoryWindows;

    public void ActiveWindow(int index)
    {
        for (int i = 0; i < inventoryWindows.Length; i++)
        {
            if(i == index)
                inventoryWindows[i].SetActive(true);
            else
                inventoryWindows[i].SetActive(false);
        }
    }
}
