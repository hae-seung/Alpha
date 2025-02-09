using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryQuestStep : QuestStep
{
    public List<QuestItemRequirement> deliveryItems = new List<QuestItemRequirement>();
    [SerializeField] private string goalNpcName;
    private bool canDelivry = false;
    
    private void Awake()
    {
        CheckItemAmount();
    }
    
    private void OnEnable()
    {
        EventsManager.Instance.itemEvent.onGetItem += GetItem;
        EventsManager.Instance.itemEvent.onConsumeItem += ConsumeItem;
        EventsManager.Instance.playerEvent.onInteractNpc += InteractNpc;
    }
    
    private void GetItem(int itemId, int amount)
    {
        for(int i = 0; i < deliveryItems.Count; i++)
        {
            QuestItemRequirement qir = deliveryItems[i];
            if (!qir.IsCompleted && qir.itemData.Id == itemId)
            {
                qir.currentAmount += amount;
                break;
            }
        }
        
        CheckItemAmount();
    }

    private void ConsumeItem(int itemId, int amount)
    {
        for (int i = 0; i < deliveryItems.Count; i++)
        {
            QuestItemRequirement qir = deliveryItems[i];
            if (qir.itemData.Id == itemId)
            {
                qir.currentAmount = qir.currentAmount - amount <= 0 ? 0 : qir.currentAmount - amount;
                break;
            }
        }
    }
    
    private void CheckItemAmount()
    {
        bool deliverable = true;
        
        //배달목록과 가지고 있는 아이템 목록 비교
        for (int i = 0; i < deliveryItems.Count; i++)
        {
            deliveryItems[i].currentAmount =
                EventsManager.Instance.itemEvent.ItemCheckRequested(deliveryItems[i].itemData.Id);
            
            if (!deliveryItems[i].IsCompleted)
            {
                deliverable = false;
                break;
            }
        }

        if (!deliverable)
        {
            canDelivry = false;
        }
        else
        {
            canDelivry = true;
        }
    }

    private void InteractNpc(string npcName)
    {
        if (goalNpcName.Equals(npcName) && canDelivry)
        {
            for (int i = 0; i < deliveryItems.Count; i++)
            {
                EventsManager.Instance.itemEvent.
                    ReduceInventoryItem(deliveryItems[i].itemData.Id, deliveryItems[i].requiredAmount);
            }
            FinishQuestStep();
        }
    }
}
