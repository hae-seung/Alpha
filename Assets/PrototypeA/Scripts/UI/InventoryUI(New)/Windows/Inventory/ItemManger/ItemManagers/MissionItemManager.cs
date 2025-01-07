using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionItemManager : MonoBehaviour
{
    public SlotHolder allItems;
    public void CreateItem(Item item)
    {
        allItems.CreateNewItem(item);
    }
}
