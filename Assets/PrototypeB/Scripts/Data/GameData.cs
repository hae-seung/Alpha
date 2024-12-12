using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameData : MonoBehaviour
{
    //�ΰ��� ������ -> ĳ����(����, ��ų, ���, �κ��丮), �� ĳ����(����, ����), ���, �̺�Ʈ
    public PlayerStat playerStat;
    public PlayerEquipment equipment;
    public PlayerInventory inventory;

    public string mapObject;
    public Transform mapPosition;

    //public List<int> enemy_ID;
    public List<string> enemy_ID;

    public GameObject player;
    public Transform playerStartPoint;

    public List<GameObject> enemies;
    public List<Transform> enemiesStartPoint;

    public List<GameObject> StartTurn;

    public GameObject ScrollView;

    public GameObject phase1UI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

public class CharacterSkill // ��ũ���ͺ� ������Ʈ
{
    public int STP;
}

public class PlayerEquipment
{
    public int headEquipment;
    public int bodyEquipment;
    public int armEquipment;
    public int legEquipment;
}

public class PlayerInventory
{
    public List<int> item_ID;
}
