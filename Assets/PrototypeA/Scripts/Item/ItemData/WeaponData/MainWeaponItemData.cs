using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum MainWeaponCategory
{
   Sword,      // 도검류
   Projectile, // 투사무기류
   Shield,     // 방패류
   Blunt,      // 둔기류
   Magic       // 마법무기류
}

public enum WeaponGripType
{
   SingleHand,
   DoubleHand
}

[CreateAssetMenu(fileName = "MainWeapon", menuName = "SO/ItemData/WeaponItem/MainWeapon")]
public class MainWeaponItemData : WeaponItemData
{ 
    private WeaponType weaponType = WeaponType.MainWeapon;
    [SerializeField] private MainWeaponCategory category;
    [SerializeField] private WeaponGripType gripType;
    [SerializeField] private bool needSubWeapon = false; // 한손 무기 시 사용 여부
    [SerializeField] private SubWeaponCategory subWeaponType; // 보조무기 Enum

    public MainWeaponCategory GetMainWeaponCategory => category;
    public WeaponGripType GetWeaponGripType => gripType;
    public bool isNeedSubWeapon => needSubWeapon;
    public SubWeaponCategory GetSubWeaponType => subWeaponType;
   
    public override WeaponType GetWeaponType()
    {
        return weaponType;
    }
}





[CustomEditor(typeof(MainWeaponItemData))]
public class MainWeaponItemDataEditor : Editor
{
    private SerializedProperty categoryProp;
    private SerializedProperty gripTypeProp;
    private SerializedProperty needSubWeaponProp;
    private SerializedProperty subWeaponTypeProp;

    private WeaponGripType previousGripType; // 이전 GripType 상태를 저장

    private void OnEnable()
    {
        // 자식 클래스 필드 가져오기
        categoryProp = serializedObject.FindProperty("category");
        gripTypeProp = serializedObject.FindProperty("gripType");
        needSubWeaponProp = serializedObject.FindProperty("needSubWeapon");
        subWeaponTypeProp = serializedObject.FindProperty("subWeaponType");

        // 현재 GripType 저장
        previousGripType = (WeaponGripType)gripTypeProp.enumValueIndex;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // 부모 클래스의 직렬화된 필드 자동 표시
        DrawPropertiesExcluding(serializedObject, "category", "gripType", "needSubWeapon", "subWeaponType");

        // 자식 클래스 필드 커스터마이징
        EditorGUILayout.PropertyField(categoryProp, new GUIContent("Category"));
        EditorGUILayout.PropertyField(gripTypeProp, new GUIContent("Grip Type"));

        // GripType이 변경되었는지 확인
        WeaponGripType currentGripType = (WeaponGripType)gripTypeProp.enumValueIndex;
        if (currentGripType != previousGripType)
        {
            if (currentGripType == WeaponGripType.DoubleHand)
            {
                needSubWeaponProp.boolValue = false; // 자동으로 false로 설정
            }
            previousGripType = currentGripType; // 이전 상태 업데이트
        }

        // GripType이 SingleHand일 경우 추가 옵션 표시
        if (currentGripType == WeaponGripType.SingleHand)
        {
            EditorGUILayout.PropertyField(needSubWeaponProp, new GUIContent("Need SubWeapon"));

            // NeedSubWeapon이 true인 경우 SubWeaponType 표시
            if (needSubWeaponProp.boolValue)
            {
                EditorGUILayout.PropertyField(subWeaponTypeProp, new GUIContent("SubWeapon Type"));
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}



