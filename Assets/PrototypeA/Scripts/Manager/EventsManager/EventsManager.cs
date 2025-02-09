using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : Singleton<EventsManager>
{
    public QuestsEvent questsEvent;
    public PlayerEvent playerEvent;
    public ItemEvent itemEvent;

    protected override void Awake()
    {
        base.Awake();
        questsEvent = new QuestsEvent();
        playerEvent = new PlayerEvent();
        itemEvent = new ItemEvent();
    }
}
