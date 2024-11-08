using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapButton : MonoBehaviour
{
    GameData gameData;

    void Start()
    {
        gameData= GameObject.Find("GameData").GetComponent<GameData>();
    }

    public void Swap()
    {
        gameData.player.GetComponent<PlayerEntity>().SwapWeapon();
    }
}
