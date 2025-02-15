using UnityEngine;

[System.Serializable]
public class QuestItemRequirement
{
    public ItemData itemData; 
    public int requiredAmount;
    [HideInInspector] public int currentAmount; 

    public bool IsCompleted => currentAmount >= requiredAmount;
}