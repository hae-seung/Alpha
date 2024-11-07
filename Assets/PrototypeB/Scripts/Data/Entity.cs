using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public PlayerStat stat;
    public Skill nextSkill = null;
    public int TPCount = 0;

    public void ChangeStat(PlayerStat _stat)
    {
        stat.STR = _stat.STR;
        stat.DEX = _stat.DEX;
        stat.INT = _stat.INT;
        stat.LUCK = _stat.LUCK;
    }

    public virtual IEnumerator ActiveSkill()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("스킬 발동!");
    }

    public virtual IEnumerator GetTurn()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("턴 받음!");
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