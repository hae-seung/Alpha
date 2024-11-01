using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameData : MonoBehaviour
{
    //인계할 데이터 -> 캐릭터(스텟, 스킬, 장비, 인벤토리), 적 캐릭터(종류, 레벨), 배경, 이벤트
    public PlayerStat playerStat;
    public CharacterSkills characterSkills;
    public PlayerEquipment equipment;
    public PlayerInventory inventory;

    public string mapObject;

    public List<int> enemy_ID;

    public Character player;
    public List<Character> enemies;

    public List<Character> StartTurn;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

[System.Serializable]
public class Character
{
    public int character_ID = 0;
    public PlayerStat stat;
    public GameObject gameObject;

    public Character()
    {
        stat=new PlayerStat();
    }

    public void ChangeStat(PlayerStat _stat)
    {
        stat.STR = _stat.STR;
        stat.DEX = _stat.DEX;
        stat.INT = _stat.INT;
        stat.LUCK = _stat.LUCK;
    }

    public void ChangeObject(GameObject _gameObject)
    {
        gameObject = _gameObject;
    }
}

[System.Serializable]
public class PlayerStat
{
    public int STR = 0;
    public int INT = 0;
    public int DEX = 0;
    public int LUCK = 0;

    public void SetSTR(int input)
    {
        STR = input;
    }

    public int GetSTR()
    {
        return STR;
    }

    public void SetDEX(int input)
    {
        DEX = input;
    }

    public int GetDEX()
    {
        return DEX;
    }

    public void SetINT(int input)
    {
        INT = input;
    }

    public int GetINT()
    {
        return INT;
    }

    public void SetLUCK(int input)
    {
        LUCK = input;
    }

    public int GetLUCK()
    {
        return LUCK;
    }
}

public class CharacterSkills
{
    public List<CharacterSkill> characterSKill_Sword;
    public List<CharacterSkill> characterSKill_Knife;
    public List<CharacterSkill> characterSKill_Mace;
    public List<CharacterSkill> characterSKill_Book;
}

public class CharacterSkill // 스크립터블 오브젝트
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
