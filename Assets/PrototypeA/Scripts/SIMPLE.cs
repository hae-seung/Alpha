using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIMPLE : MonoBehaviour
{
    private string npcName;

    private void Awake()
    {
        npcName = gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("interact!!");
            EventsManager.instance.playerEvent.InteractNpc(npcName);
        }
    }
}
