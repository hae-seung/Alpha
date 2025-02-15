using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink Story")]

    [SerializeField] private TextAsset inkJson;

    private Story story;

    private int currentChoiceIndex = 1;
    
    private bool dialoguePlaying = false;

    private void Awake()
    {
        story=new Story(inkJson.text);
    }

    private void OnEnable()
    {
        EventsManager.instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        EventsManager.instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
    }

    private void OnDisable()
    {
        EventsManager.instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        EventsManager.instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialoguePlaying==false)
            {
                return;
            }

            ContinueOrExitStory(); 
        }
    }

    private void EnterDialogue(string knotName)
    {
        if(dialoguePlaying==true)
        {
            return;
        }

        dialoguePlaying = true;

        EventsManager.instance.dialogueEvents.DialogueStarted();

        if(!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            Debug.LogWarning("Knot 이름이 비어있음");
        }

        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);

            currentChoiceIndex = -1;
        }

        if(story.canContinue==true)
        {
            string dialogueLine = story.Continue();

            EventsManager.instance.dialogueEvents.DisplayDialogue(dialogueLine,story.currentChoices);
        }
        else if(story.currentChoices.Count ==0)
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        //Debug.Log("대화문 탈출");

        dialoguePlaying=false;

        EventsManager.instance.dialogueEvents.DialogueFinished();

        story.ResetState();
    }
}
