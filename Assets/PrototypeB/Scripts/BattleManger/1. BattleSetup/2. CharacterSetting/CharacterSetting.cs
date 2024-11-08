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

    private void PlacePlayerObject(GameData gameData)                                                   // 플레이어 데이터 가져와서 오브젝트 생성
    {                                                                                                   // GameData 파일의 player 변수에 데이터 저장
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

            //장비 추가
        }
        else
        {
            if (isActiveLog)
            {
                Debug.Log("Player was not found");
            }
        }
    }

    private void PlaceEnemyObject(GameData gameData)                                                    // 적 데이터 가져와서 오브젝트 생성
    {                                                                                                   // GameData 파일의 enemies 변수에 데이터 저장
        for (int i = 0; i < gameData.enemy_ID.Count; i++)                                               // 초기 스탯은 1~4 사이의 값을 넣어줌
        {
            GameObject enemyPrefab = Resources.Load<GameObject>(gameData.enemy_ID[i].ToString());

            if (enemyPrefab != null)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, gameData.enemiesStartPoint[i].position, Quaternion.identity);
                
                //스탯 추가 (랜덤)
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
