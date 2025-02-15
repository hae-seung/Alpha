using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Quest> questMap;

    private void Awake()
    {
        questMap = CreateQuestMap();
    }

    private void OnEnable()
    {
        EventsManager.instance.questsEvent.onStartQuest += StartQuest;
        EventsManager.instance.questsEvent.onAdvanceQuest += AdvanceQuest;
        EventsManager.instance.questsEvent.onFinishQuest += FinishQuest;
    }

    private void Start()
    {
        foreach (Quest quest in questMap.Values)
        {
            EventsManager.instance.questsEvent.QuestStateChange(quest);
        }
    }

    private void OnDisable()
    {
        //todo:구독취소
    }

    private void Update()
    {
        foreach (Quest quest in questMap.Values)
        {
            if(quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.Id, QuestState.CAN_START);
                //Debug.Log($"퀘스트의 상태가 시작가능으로 변경");
            }
        }
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests)
        {
            if (idToQuestMap.ContainsKey(questInfo.Id))
            {
                Debug.Log($"이미 저장되었던 퀘스트입니다 + {questInfo.Id}");
            }
            idToQuestMap.Add(questInfo.Id, new Quest(questInfo));
        }

        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        
        if(quest == null)
            Debug.Log($"{id}에 해당하는 퀘스트가 딕셔너리에 존재하지 않습니다");
        return quest;
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        EventsManager.instance.questsEvent.QuestStateChange(quest);//event호출
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        //quest에 대하여 RequirementSO 조건을 모두 만족하는지 확인
        QuestPreRequirementSO questPreRequirement = quest.info.questPreRequirement;
        
        //레벨, 호감도, 아이템, 선행퀘
        if (EventsManager.instance.playerEvent.CheckPlayerLevel() < questPreRequirement.needLevel)
        {
            Debug.Log("레벨이 안됨");
            return false;
        }

        if (EventsManager.instance.playerEvent.CheckNpcLikeability(quest.info.questProviderName) <
            questPreRequirement.needNpcLikeability)
        {
            Debug.Log("호감도가 안됨");
            return false;
        }

        if (!HasRequirementItems(questPreRequirement))
        {
            Debug.Log("아이템이 없음");
            return false;
        }

        if (!CompletePrerequisites(questPreRequirement))
        {
            Debug.Log("사전퀘스트 완료가 안됨");
            return false;
        }

        return true;
    }

    private bool CompletePrerequisites(QuestPreRequirementSO questPreRequirement)
    {
        for (int i = 0; i < questPreRequirement.questPrerequisites.Length; i++)
        {
            if (GetQuestById(questPreRequirement.questPrerequisites[i].Id).state != QuestState.FINISHED)
                return false;
        }

        return true;
    }

    private bool HasRequirementItems(QuestPreRequirementSO requirement)
    {
        for (int i = 0; i < requirement.needItems.Length; i++)
        {
            if (EventsManager.instance.itemEvent.ItemCheckRequested(requirement.needItems[i].itemData.Id) <
                requirement.needItems[i].preRequiredAmount)
                return false;
        }

        return true;
    }

    private void StartQuest(string id)
    {
        Debug.Log("퀘스트 시작");
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.Id, QuestState.IN_PORGRESS);
    }

    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.MoveToNextStep();
        
        if(quest.CurrentStepExists())
            quest.InstantiateCurrentQuestStep(this.transform);
        else
        {
            ChangeQuestState(quest.info.Id, QuestState.CAN_FINISH);
        }
    }

    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        ClaimRewards(quest);
        ChangeQuestState(quest.info.Id, QuestState.FINISHED);
    }

    private void ClaimRewards(Quest quest)
    {
        //todo: quest.info의 리워드 목록 지급
        Debug.Log("퀘스트를 완료하였습니다. 보상을 지급합니다");
    }
}
