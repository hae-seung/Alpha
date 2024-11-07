using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public Skill skill;

    public void ClickSkillButtonEvent()
    {
        PlayerEntity.selectedPhase1Skill= skill;
        PlayerEntity.phase1Flag = false;
        
    }
}
