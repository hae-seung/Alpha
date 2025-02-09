using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private GameObject contentParent;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private DialogueChoiceButton[] choiceButtons;

    private void Awake()
    {
        contentParent.SetActive(false);
        ResetPanel();
    }

    private void OnEnable()
    {
        EventsManager.instance.dialogueEvents.onDialogueStarted += DialogueStarted;
        EventsManager.instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        EventsManager.instance.dialogueEvents.onDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        EventsManager.instance.dialogueEvents.onDialogueStarted -= DialogueStarted;
        EventsManager.instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        EventsManager.instance.dialogueEvents.onDisplayDialogue -= DisplayDialogue;
    }

    private void DialogueStarted()
    {
        contentParent.SetActive(true);
    }

    private void DialogueFinished()
    {
        contentParent.SetActive(false);

        ResetPanel();
    }

    private void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        dialogueText.text = dialogueLine;

        if(dialogueChoices.Count>choiceButtons.Length)
        {
            Debug.LogError("버튼 수 보다 선택지가 더 많음.");
        }

        foreach(DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = dialogueChoices.Count - 1;

        for(int inkChoiceIndex=0;inkChoiceIndex<dialogueChoices.Count;inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if(inkChoiceIndex==0)
            {
                choiceButton.SelectButton();
                EventsManager.instance.dialogueEvents.UpdateChoiceIndex(0);     // DialogueChoiceButton.cs 파일의 OnSelect부분과 버튼 SetActive(true) 부분이 같은 프레임에서 일어나는 잠재적 문제
            }

            choiceButtonIndex--;
        }
    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}
