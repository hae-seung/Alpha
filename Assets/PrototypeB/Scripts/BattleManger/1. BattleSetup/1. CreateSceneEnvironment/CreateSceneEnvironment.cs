using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSceneEnvironment : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isActiveLog = false;

    void Start()
    {
        gameObject.GetComponentInParent<BattleSetup>().Initialize(this);
    }

    public void PlaceMapObject(GameData gameData)                                               // �� ������ ���ҽ� ���Ͽ��� �����ͼ� ������Ʈ ����
    {
        GameObject mapPrefab = Resources.Load<GameObject>(gameData.mapObject);

        if (mapPrefab != null)
        {
            //Instantiate(mapPrefab, Vector3.zero, Quaternion.identity);
            Instantiate(mapPrefab, gameData.mapPosition.position, Quaternion.identity);

            if(isActiveLog)
            {
                Debug.Log("Map instantiated");
            }
        }
        else
        {
            if (isActiveLog)
            {
                Debug.Log("Map was not found");
            }
        }
    }
}
