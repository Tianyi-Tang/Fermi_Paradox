using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有科技加成的父类
/// </summary>
public class BuffSO : ScriptableObject
{
    protected bool isInt;
    protected bool isFloat;
    

    public virtual int getGameStatsNum()
    {
        return -1;
    }

    public virtual GameParameterSO getGameStat(int num)
    {
        return null;
    }

    public virtual float getGameStat_value_float (int num)
    {
        return -1;
    }

    public virtual int getGameStat_value_int(int num)
    {
        return -1;
    }
}
