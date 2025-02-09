using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance { get; private set; }

    public DialogueEvents dialogueEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Events Manager");
        }

        instance = this;

        dialogueEvents = new DialogueEvents();
    }
}
