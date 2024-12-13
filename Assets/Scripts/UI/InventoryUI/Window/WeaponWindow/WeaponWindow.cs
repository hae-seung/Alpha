using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWindow : MonoBehaviour
{
    [Header("켜지면 제일 먼저 보이는 화면")]
    public GameObject equipSlotSet;

    [Header("버튼 클릭시 활성화 될 창")] 
    public WeaponSelectWindow weaponSelectWindow;
    public ArmorSelectWindow armorSelectWindow;
    
    public void OnEnable()
    {
        Transform[] child = GetComponentsInChildren<Transform>();
        for(int i = 1; i<child.Length; i++)
            child[i].gameObject.SetActive(false);
        
        equipSlotSet.SetActive(true);
    }


    public void Classify(EquipItem newItem, int idx, int stackIdx)
    {
        
    }


    public void OnClickWeaponSlot(string region)
    {
        
    }

    public void OnClickArmorSlot(string region)
    {
        
    }
}
