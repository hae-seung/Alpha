using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    [Header("Dialogue (optional)")]

    [SerializeField] private string dialogueKnotName;

    private void Awake()
    {
        if (!dialogueKnotName.Equals(""))
        {
            //EventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!dialogueKnotName.Equals(""))
            {
                EventsManager.instance.dialogueEvents.EnterDialogue(dialogueKnotName);
            }
        }
    }
}