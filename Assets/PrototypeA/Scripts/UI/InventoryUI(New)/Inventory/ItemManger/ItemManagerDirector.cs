using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerDirector : MonoBehaviour
{
    //스크립트를 모두 분할시켜야함
    public ArmorItemManager armorItemManager;
    public AccItemManager accItemManager;
    public WeaponItemManager weaponItemManager;
    public ConsumeItemManager consumeItemManager;
    public MissionItemManager missionItemManager;
    
    
    public void CreateArmorItem(ArmorItem armorItem)
    {
        armorItemManager.CreateItem(armorItem);
    }

    public void CreateAccessoriesItem()
    {
        accItemManager.CreateItem();
    }

    public void CreateWeaponItem()
    {
        weaponItemManager.CreateItem();
    }

    public void CreateConsumeItem()
    {
        consumeItemManager.CreateItem();
    }

    public void CreateMissionItem()
    {
        missionItemManager.CreateItem();
    }
}
