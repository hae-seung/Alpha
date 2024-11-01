using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CalculateStartTurn : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponentInParent<BattleSetup>().Initialize(this);
    }

    public void CalStartTurn(GameData gameData)                                                     // 적&아군 모든 캐릭터의 DEX와 INT의 합으로 시작 턴 순서를 정함.
    {
        gameData.StartTurn.Add(gameData.player);

        for (int i = 0; i < gameData.enemies.Count; i++)
        {
            gameData.StartTurn.Add(gameData.enemies[i]);
        }

        gameData.StartTurn.Sort(compareTurn);
    }

    public int compareTurn(Character a, Character b)
    {
        return a.stat.GetDEX()+ a.stat.GetINT() > b.stat.GetDEX() + b.stat.GetINT() ? -1 : 1;
    }
}

