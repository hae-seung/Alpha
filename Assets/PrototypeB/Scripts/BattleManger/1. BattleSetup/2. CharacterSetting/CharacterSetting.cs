using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CharacterSetting : MonoBehaviour
{
    public bool isActiveLog = false;

    public GameObject dummyObject;

    void Start()
    {
        gameObject.GetComponentInParent<BattleSetup>().Initialize(this);
    }

    public void PlaceCharacterObjects(GameData gameData)
    {
        PlacePlayerObject(gameData);
        PlaceEnemyObject(gameData);
    }

    private void PlacePlayerObject(GameData gameData)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Player");

        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            //Ω∫≈» √ﬂ∞°
            //gameData.player.stat = gameData.playerStat;
            //gameData.player.gameObject = playerPrefab;

            gameData.player.ChangeStat(gameData.playerStat);
            gameData.player.ChangeObject(playerPrefab);

            if (isActiveLog)
            {
                Debug.Log("Player instantiated");
            }

            //¿Â∫Ò √ﬂ∞°
        }
        else
        {
            if (isActiveLog)
            {
                Debug.Log("Player was not found");
            }
        }
    }

    private void PlaceEnemyObject(GameData gameData)
    {
        for (int i = 0; i < gameData.enemy_ID.Count; i++)
        {
            GameObject enemyPrefab = Resources.Load<GameObject>(gameData.enemy_ID[i].ToString());

            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);

                Character NewCharacter=new Character();
                NewCharacter.character_ID = gameData.enemy_ID[i];
               
                //Ω∫≈» √ﬂ∞° (∑£¥˝)
                NewCharacter.stat.STR   = Random.Range(1, 4);
                NewCharacter.stat.DEX   = Random.Range(1, 4);
                NewCharacter.stat.INT   = Random.Range(1, 4);
                NewCharacter.stat.LUCK  = Random.Range(1, 4);

                NewCharacter.gameObject = enemyPrefab;
                
                gameData.enemies.Add(NewCharacter);

                if (isActiveLog)
                {
                    Debug.Log("Enemy instantiated");
                }
            }
            else
            {
                if (isActiveLog)
                {
                    Debug.Log("Enemy was not found");
                }
            }
        }
    }
}
