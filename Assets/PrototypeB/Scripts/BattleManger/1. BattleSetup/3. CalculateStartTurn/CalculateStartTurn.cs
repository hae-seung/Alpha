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

    public void CalStartTurn(GameData gameData)                                                     // ��&�Ʊ� ��� ĳ������ DEX�� INT�� ������ ���� �� ������ ����.
    {
        gameData.StartTurn.Add(gameData.player);

        for (int i = 0; i < gameData.enemies.Count; i++)
        {
            gameData.StartTurn.Add(gameData.enemies[i]);
        }

        gameData.StartTurn.Sort(compareTurn);
    }

    public int compareTurn(GameObject a, GameObject b)
    {
        //Debug.Log(a.gameObject.name+"�� ���� �� : " + a.GetComponent<Entity>().stat.GetDEX());
        //Debug.Log(b.gameObject.name + "�� ���� �� : " + b.GetComponent<Entity>().stat.GetDEX());
        return (a.GetComponent<Entity>().stat.GetDEX()+ a.GetComponent<Entity>().stat.GetINT()) > (b.GetComponent<Entity>().stat.GetDEX() + b.GetComponent<Entity>().stat.GetINT()) ? -1 : 1;
    }
}

