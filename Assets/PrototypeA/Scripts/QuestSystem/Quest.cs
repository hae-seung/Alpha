using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
   //static info
   public QuestInfoSO info { get; private set; }
   
   //state info
   public QuestState state;
   private int currentQuestStepIndex;

   public Quest(QuestInfoSO questInfo)
   {
       this.info = questInfo;
       this.state = QuestState.REQUIREMENTS_NOT_MET;
       this.currentQuestStepIndex = 0;
   }

   public void MoveToNextStep()
   {
       currentQuestStepIndex++;
   }

   public bool CurrentStepExists()
   {
       return currentQuestStepIndex < info.questStepPrefabs.Length;
   }

   public void InstantiateCurrentQuestStep(Transform parentTransform)
   {
       GameObject questStepPrefab = GetCurrentQuestStepPrefab();
       if (questStepPrefab != null)
       {
           QuestStep questStep = GameObject.Instantiate<GameObject>(questStepPrefab, parentTransform)
               .GetComponent<QuestStep>();
           questStep.InitializeQuestStep(info.Id);
       }
   }

   private GameObject GetCurrentQuestStepPrefab()
   {
       GameObject questStepPrefab = null;
       if (CurrentStepExists())
       {
           questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
       }
       else
       {
           Debug.Log("더이상 진행할 퀘스트가 없습니다");
       }

       return questStepPrefab;
   }
}
