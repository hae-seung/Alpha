using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{
    private int experience;

    private int requireNextLevelExperience;
    private int level;

    private void Awake()
    {
        experience = 0;
        level = 1;
        requireNextLevelExperience = 10;
    }

    private void OnEnable()
    {
        EventsManager.Instance.playerEvent.onGainedExperience += GainedExperience;
        EventsManager.Instance.playerEvent.onCheckPlayerLevel += CheckPlayerLevel;
    }

    private int CheckPlayerLevel()
    {
        return level;
    }

    private void GainedExperience(int exp)
    {
        experience += exp;
        if (experience >= requireNextLevelExperience)
        {
            level++;
            experience -= requireNextLevelExperience;
            requireNextLevelExperience *= 2;//todo :임시로 작성됨
        }
    }
}
