using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储所有文明拥有的buff，以及buff带来的数值加成
/// </summary>
[CreateAssetMenu(fileName = "CivilBuff", menuName = "SO/Civilization/Civil/CivilBuff")]
public class CivilBuffSO : ScriptableObject
{
    [SerializeField]private List<BuffSO> allbuff = new List<BuffSO>();//存储所有的buff
    private Dictionary<GameStatsSO, float> addtionalGameStats_buff = new Dictionary<GameStatsSO, float>();//存储buff 带来的数值加成

    /// <summary>
    /// 新增文明拥有的buff，并调整数值
    /// </summary>
    /// <param name="buff">需要添加的buff</param>
    public void addBuff(BuffSO buff)
    {
        allbuff.Add(buff);

        int GameStatsNum = buff.getGameStatsNum();

        for (int i = 0; i < GameStatsNum;i++)
            addVale_gameStats(buff.getGameStat(i), buff.getGameStat_value_float(i));
        
    }

    /// <summary>
    /// 移除文明拥有的buff，并调整数值
    /// </summary>
    /// <param name="buff">被移除的buff</param>
    public void removeBuff(BuffSO buff)
    {
        if (allbuff.Contains(buff))
        {
            allbuff.Remove(buff);

            int GameStatsNum = buff.getGameStatsNum();
            for (int i = 0; i < GameStatsNum; i++)
                subtractValue_gameStats(buff.getGameStat(i), buff.getGameStat_value_float(i));
        }
            
    }

    /// <summary>
    /// 获得对应 GameStats 的加成数值
    /// </summary>
    /// <param name="gameStats">需要获取加成数值的 GameStats</param>
    /// <returns>GameStats的加成数值</returns>
    public float getAdditonalGameStats(GameStatsSO gameStats)
    {
        float value;
        if (addtionalGameStats_buff.TryGetValue(gameStats, out value))
            return value;
        else
            return 0;
    }

    /// <summary>
    /// 增加被给予 GameStats 的加成数值 
    /// </summary>
    /// <param name="gameStats">需要增加数值的 GameStats</param>
    /// <param name="addtioanl_value">增加的数值</param>
    private void addVale_gameStats(GameStatsSO gameStats, float addtioanl_value)
    {
        float orginal_vlaue;
        if (!addtionalGameStats_buff.TryGetValue(gameStats, out orginal_vlaue))
        {
            addtionalGameStats_buff.Add(gameStats, addtioanl_value);
        }
        else
            addtionalGameStats_buff[gameStats] = orginal_vlaue + addtioanl_value;
            
    }

    /// <summary>
    /// 减少被给予 GameStats 的加成数值 
    /// </summary>
    /// <param name="gameStats">需要减少数值的 GameStats</param>
    /// <param name="addtioanl_value">减少的数值</param>
    private void subtractValue_gameStats(GameStatsSO gameStats, float addtioanl_value)
    {
        addtionalGameStats_buff[gameStats] -= addtioanl_value;
    }

    
}
