using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent
{
    /// <summary>
    /// player가 Npc와 상호작용 -> NPC가 호출
    /// </summary>
    public event Action<string> onInteractNpc;
    public void InteractNpc(string npcName)
    {
        onInteractNpc?.Invoke(npcName);
    }

    /// <summary>
    /// 플레이어 레벨이 필요할때 호출
    /// </summary>
    public event Func<int> onCheckPlayerLevel;
    public int CheckPlayerLevel()
    {
        return onCheckPlayerLevel?.Invoke() ?? 1;
    }

    /// <summary>
    /// 어떤 npc의 호감도 확인
    /// </summary>
    public event Func<string, int> onCheckNpcLikeability;
    public int CheckNpcLikeability(string npcName)
    {
        return onCheckNpcLikeability?.Invoke(npcName) ?? 0;
    }
    
    /// <summary>
    /// 몬스터 처치 시 호출해야함
    /// </summary>
    public event Action<int> onGainedExperience;
    public void GainedExperience(int exp) 
    {
        onGainedExperience?.Invoke(exp);
    }
    
    
}
