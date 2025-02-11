using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance { get; private set; }

    public DialogueEvents dialogueEvents;

    public QuestsEvent questsEvent;
    public PlayerEvent playerEvent;
    public ItemEvent itemEvent;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Events Manager");
        }

        instance = this;

        dialogueEvents = new DialogueEvents();

        questsEvent = new QuestsEvent();
        playerEvent = new PlayerEvent();
        itemEvent = new ItemEvent();
    }
}
