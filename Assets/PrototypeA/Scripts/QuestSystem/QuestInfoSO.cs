using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "SO/Quest/QuestInfoSO")]
public class QuestInfoSO : ScriptableObject
{
   [field: SerializeField] public string Id { get; private set; }
   
   [Header("General")] public string displayName;
   [Header("QuestProvider")] public string questProviderName;
   [Header("Requirements")] public QuestPreRequirementSO questPreRequirement;
   [Header("Steps")] public GameObject[] questStepPrefabs;
   [Header("Rewards")] public QuestRewardSO questReward;
   
   //id가 스크립터블 오브젝트의 이름으로 결정되도록 보장 
   private void OnValidate()
   {
#if UNITY_EDITOR
       Id = this.name;
       UnityEditor.EditorUtility.SetDirty(this);
#endif
   }
   
   
}
