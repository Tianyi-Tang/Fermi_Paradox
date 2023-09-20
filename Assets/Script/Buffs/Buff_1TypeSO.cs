using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 带有一个 GameStats 的数值加成或减益
/// </summary>
[CreateAssetMenu(fileName = "Buff_1Type",menuName = "SO/Buff/BuffNum/1Type")]
public class Buff_1TypeSO : BuffSO
{
    [SerializeField]private GameStatsSO technologyBuff;
    [SerializeField]private float paramete_flaot;
    [SerializeField] private int paramete_int;

    public override int getGameStatsNum()
    {
        return 1;
    }

    public override GameStatsSO getGameStat(int num)
    {
        if (num == 0)
            return technologyBuff;
        else
            return null;
    }

    public override float getGameStat_value_float(int num)
    {
        if (num == 0 && isFloat)
            return paramete_flaot;    
        else
            return -1;
    }

    public override int getGameStat_value_int(int num)
    {
        if (num == 0 && isInt)
            return paramete_int;
        else
            return -1;
    }
}
