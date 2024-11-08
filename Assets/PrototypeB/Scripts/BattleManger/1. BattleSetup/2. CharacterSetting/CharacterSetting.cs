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

    private void PlacePlayerObject(GameData gameData)                                                   // �÷��̾� ������ �����ͼ� ������Ʈ ����
    {                                                                                                   // GameData ������ player ������ ������ ����
        GameObject playerPrefab = Resources.Load<GameObject>("Player");

        if (playerPrefab != null)
        {
            GameObject newPlayer =Instantiate(playerPrefab, gameData.playerStartPoint.position, Quaternion.identity);

            gameData.player = newPlayer;

            newPlayer.GetComponent<PlayerEntity>().phase1UI = gameData.phase1UI;
            newPlayer.GetComponent<PlayerEntity>().skillContainer = gameData.ScrollView;

            if (isActiveLog)
            {
                Debug.Log("Player instantiated");
            }

            //��� �߰�
        }
        else
        {
            if (isActiveLog)
            {
                Debug.Log("Player was not found");
            }
        }
    }

    private void PlaceEnemyObject(GameData gameData)                                                    // �� ������ �����ͼ� ������Ʈ ����
    {                                                                                                   // GameData ������ enemies ������ ������ ����
        for (int i = 0; i < gameData.enemy_ID.Count; i++)                                               // �ʱ� ������ 1~4 ������ ���� �־���
        {
            GameObject enemyPrefab = Resources.Load<GameObject>(gameData.enemy_ID[i].ToString());

            if (enemyPrefab != null)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, gameData.enemiesStartPoint[i].position, Quaternion.identity);
                
                //���� �߰� (����)
                newEnemy.GetComponent<Entity>().stat.STR   = Random.Range(1, 4);
                newEnemy.GetComponent<Entity>().stat.DEX   = Random.Range(1, 4);
                newEnemy.GetComponent<Entity>().stat.INT   = Random.Range(1, 4);
                newEnemy.GetComponent<Entity>().stat.LUCK  = Random.Range(1, 4);
                
                //NewCharacter.gameObject = enemyPrefab;
                
                gameData.enemies.Add(newEnemy);

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
