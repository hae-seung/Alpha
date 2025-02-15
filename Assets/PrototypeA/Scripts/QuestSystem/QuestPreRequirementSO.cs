using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PreQuestItemRequirement
{
    public ItemData itemData; 
    public int preRequiredAmount;
}

[CreateAssetMenu(fileName = "QuestRequirementSO", menuName = "SO/Quest/QuestRequirementSO")]
public class QuestPreRequirementSO : ScriptableObject
{
    //퀘스트를 받기 전 필요한 요소들
    [Header("사전 요구레벨")] public int needLevel;

    [Header("사전 요구아이템")] public PreQuestItemRequirement[] needItems;

    [Header("사전 요구 NPC 호감도")] public int needNpcLikeability;

    [Header("선행퀘스트")] public QuestInfoSO[] questPrerequisites;
}
