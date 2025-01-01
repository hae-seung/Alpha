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

    public void CreateNewItem(Item item)
    {
        switch (item)
        {
            case ArmorItem armorItem :
                armorItemManager.CreateItem(armorItem);
                break;
            case AccItem accItem:
                accItemManager.CreateItem();
                break;
            case WeaponItem weaponItem:
                weaponItemManager.CreateItem();
                break;
            
            //todo: 아이템 클래스 수정
        }
    }

    public void RemoveItemAllTabs(Item item)
    {
        switch (item)
        {
            case ArmorItem armorItem :
                armorItemManager.RemoveItem(armorItem);
                break;
            case AccItem accItem:
                accItemManager.RemoveItem();
                break;
            case WeaponItem weaponItem:
                weaponItemManager.RemoveItem();
                break;
            
            //todo: 아이템 클래스 수정
        }
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