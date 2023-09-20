using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于存放文明所有非条件性的基础属性
/// </summary>
[CreateAssetMenu(fileName = "CivilBasicInfor", menuName = "SO/Civilization/Civil/CivilBasicInfor")]
public class CivilBasicInforSO : ScriptableObject
{
    //文明的适宜温度
    [SerializeField] private float maxSuitableTemperature;
    [SerializeField] private float minSuitableTemperature;

    public int miningSpeed; //每秒钟文明从一个行星系收获的资源

    public int scienceDevelopmentSpeed; //文明每秒钟科技发展的速度

    public float detectionStats = 0;

    private Dictionary<GameParameterSO, float> allBasicInfor_float = new Dictionary<GameParameterSO, float>();
    private Dictionary<GameParameterSO, int> allBasicInfor_int = new Dictionary<GameParameterSO, int>();

    /// <summary>
    /// 将该 class 里面的有关 GameStats 的成员变量，存储在对应的 Dictionary 里面
    /// </summary>
    public void initialDictionary()
    {
        foreach (GameParameterSO gameStat in GameStatsContainer.instance.getAllGameStatsWithInCivilBasicInfor())
        {
            if (gameStat.getSpecificName() != null)
            {
                if (gameStat.isValueFloat())
                    allBasicInfor_float.Add(gameStat, (float) this.GetType().GetField(gameStat.getSpecificName()).GetValue(this));
                else
                    allBasicInfor_int.Add(gameStat, (int)this.GetType().GetField(gameStat.getSpecificName()).GetValue(this));
            }
        }
    }

    /// <summary>
    /// 获取给予 GameStats 的数值，注意该 GameStats 必须为 float type
    /// </summary>
    /// <param name="gameStat">需要获取数值的 GameStats</param>
    /// <returns>该 GameStats 的值</returns>
    public float getBasicInfor_float(GameParameterSO gameStat)
    {
        float value;
        if (allBasicInfor_float.TryGetValue(gameStat, out value))
            return value;
        else
            return 0;
    }

    /// <summary>
    /// 获取给予 GameStats 的数值，注意该 GameStats 必须为 int type
    /// </summary>
    /// <param name="gameStat">需要获取数值的 GameStats</param>
    /// <returns>该 GameStats 的值</returns>
    public int getBasicInfor_int(GameParameterSO gameStat)
    {
        int value;
        if (allBasicInfor_int.TryGetValue(gameStat, out value))
            return value;
        else
            return 0;
    }

    /// <summary>
    /// 增加给予 GameStats 的数值，注意该 GameStats 为 float type
    /// </summary>
    /// <param name="gameStat">需要增加数值的 GameStats</param>
    /// <param name="addValue">需要增加的数值</param>
    public void addValueToBasicInfor(GameParameterSO gameStat, float addValue)
    {
        float value;
        if (!allBasicInfor_float.TryGetValue(gameStat, out value))
            return;
        allBasicInfor_float[gameStat] += addValue;
        this.GetType().GetField(gameStat.getSpecificName()).SetValue(this, addValue + value);
    }

    /// <summary>
    /// 增加给予 GameStats 的数值，注意该 GameStats 为 int type
    /// </summary>
    /// <param name="gameStat">需要增加数值的 GameStats</param>
    /// <param name="addValue">需要增加的数值</param>
    public void addValueToBasicInfor(GameParameterSO gameStat, int addValue)
    {
        int value;
        if (!allBasicInfor_int.TryGetValue(gameStat, out value))
            return;
        allBasicInfor_int[gameStat] += addValue;
        this.GetType().GetField(gameStat.getSpecificName()).SetValue(this, addValue + value);
    }
}
