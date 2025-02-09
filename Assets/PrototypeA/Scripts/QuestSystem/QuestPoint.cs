using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")] 
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")] 
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private string npcName;
    private string questId;
    private int likeability;
    
    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPoint.Id;
        npcName = startPoint ? questInfoForPoint.questProviderName : gameObject.name;
        likeability = 0;
    }

    private void OnEnable()
    {
        EventsManager.Instance.questsEvent.onQuestStateChange += QuestStateChange;
        EventsManager.Instance.playerEvent.onCheckNpcLikeability += CheckNpcLikeability;
    }

    private int CheckNpcLikeability(string questProviderName)
    {
        if (npcName.Equals(questProviderName))
            return likeability;
        return 0;
    }

    private void OnDisable()
    {
        //구독해지
    }

    private void QuestStateChange(Quest quest)
    {
        if (questId.Equals(quest.info.Id))
        {
            currentQuestState = quest.state;
            Debug.Log($"퀘스트 아이디: {questId} 상태변화 : {currentQuestState}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            InteractWithPlayer();
    }
    

    private void InteractWithPlayer()
    {
        Debug.Log("interact!");
        
        EventsManager.Instance.playerEvent.InteractNpc(npcName);
        
        
        ///바뀐 퀘스트 상태에 대해서
        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            //퀘스트 시작
            EventsManager.Instance.questsEvent.StartQuest(questId);
        }
        else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            Debug.Log("퀘스트 완료!");
            //퀘스트 종료
            EventsManager.Instance.questsEvent.FinishQuest(questId);
        }
    }
}
