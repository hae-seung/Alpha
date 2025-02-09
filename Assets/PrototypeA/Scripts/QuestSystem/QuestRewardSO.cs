
using UnityEngine;

[CreateAssetMenu(fileName = "QuestRewardSO", menuName = "SO/Quest/QuestRewardSO")]
public class QuestRewardSO : ScriptableObject
{
    [Header("보상경험치")] public int rewardExperience;

    [Header("보상 골드")] public int rewardGold;

    [Header("보상 아이템")] public ItemData[] rewardItems;

    [Header("보상 NPC 호감도")] public int rewardNpcLikeability;

    [Header("보상 스텟")] public StatusData needStatus;
}
