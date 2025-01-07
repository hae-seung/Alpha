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
                accItemManager.CreateItem(accItem);
                break;
            case WeaponItem weaponItem:
                weaponItemManager.CreateItem();
                break;
            case IConsumable consumable:
                consumeItemManager.CreateItem(consumable);
                break;
            case MissionItem missionItem:
                missionItemManager.CreateItem(missionItem);
                break;
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
                accItemManager.RemoveItem(accItem);
                break;
            case WeaponItem weaponItem:
                weaponItemManager.RemoveItem();
                break;
            
            //todo : Consume이랑 Mission은 구현 불필요
        }
    }
}