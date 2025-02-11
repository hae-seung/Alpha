using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectItemQuestStep : QuestStep
{
    public List<QuestItemRequirement> itemRequirements = new List<QuestItemRequirement>();

    private void Awake()
    {
        CheckItemAmount();
    }

    private void OnEnable()
    {
        //아이템을 획득햇을때 호출당함
        EventsManager.instance.itemEvent.onGetItem += GetItem;
        //플레이어가 갑자기 아이템을 소비해버리면 갯수 감소
        EventsManager.instance.itemEvent.onConsumeItem += ConsumeItem;
    }
    

    private void GetItem(int itemId, int amount)
    {
        for (int i = 0; i < itemRequirements.Count; i++)
        {
            QuestItemRequirement qir = itemRequirements[i];
            if (!qir.IsCompleted && qir.itemData.Id == itemId)
            {
                qir.currentAmount += amount;
                
                if(qir.IsCompleted)
                    FinishQuestStep();
                
                //break; //상황보고 넣을지 말지
            }
        }
    }

    private void ConsumeItem(int itemId, int amount)
    {
        for (int i = 0; i < itemRequirements.Count; i++)
        {
            QuestItemRequirement qir = itemRequirements[i];
            if (qir.itemData.Id == itemId)
            {
                qir.currentAmount = qir.currentAmount - amount <= 0 ? 0 : qir.currentAmount - amount;
                break;
            }
        }
    }

    private void CheckItemAmount()
    {
        bool hasAllItem = true;
        for (int i = 0; i < itemRequirements.Count; i++)
        {
            itemRequirements[i].currentAmount =
                EventsManager.instance.itemEvent.ItemCheckRequested(itemRequirements[i].itemData.Id);

            if (!itemRequirements[i].IsCompleted)
                hasAllItem = false;
        }

        if (hasAllItem)
            StartCoroutine(nameof(DisplayPlayerWhatWasQuest));
    }

    private IEnumerator DisplayPlayerWhatWasQuest()
    {
        yield return new WaitForSeconds(2);
        FinishQuestStep();
    }

    private void OnValidate()
    {
#if UNITY_EDITOR
        foreach (var requirement in itemRequirements)
        {
            if (requirement.itemData is EquipItemData)
                requirement.requiredAmount = 1;
        }
#endif
    }
}
