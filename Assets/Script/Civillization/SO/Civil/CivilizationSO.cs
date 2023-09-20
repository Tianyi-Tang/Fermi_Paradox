using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 文明的属性，标签和档案库
/// </summary>
[CreateAssetMenu(fileName = "Civilization", menuName = "SO/Civilization/Civilization")]
public class CivilizationSO : ScriptableObject
{
    [SerializeField]private string CivilizationName;
    [SerializeField]private bool playControl = false; //该文明是否由玩家控制
    [SerializeField] private List<PlanetarySystem> planetarySystems;

    [SerializeField] private CivilArchivesSO civilArchives;

    [SerializeField] private CivilBasicInforSO civilBasicInfor;
    [SerializeField] private CivilScienceSO civilScience;
    [SerializeField] private CivilBuffSO civilBuff;

    private CivilStatus civilStatus;

    public void setCivilStatus(CivilStatus civilStatus)
    {
        this.civilStatus = civilStatus;
    }

    /// <summary>
    /// 当文明占领一个新的行星系，通知文明更新行星系的信息
    /// </summary>
    /// <param name="planetarySystem">新被占领的行星系</param>
    public void addNewPlanetarySystem(PlanetarySystem planetarySystem)
    {
        planetarySystems.Add(planetarySystem);
        CivillizationManager.instance.addPlanetSystem(planetarySystem);
    }

    /// <summary>
    /// 当文明失去一个行星系时，通知文明更新行星系的信息
    /// </summary>
    /// <param name="planetarySystem"></param>
    public void deletePlanetarySystem(PlanetarySystem planetarySystem)
    {
        planetarySystems.Remove(planetarySystem);
        CivillizationManager.instance.deletePlanetSystem(planetarySystem);
    }

    /// <summary>
    /// 清除所有文明拥有的行星
    /// </summary>
    public void clearOwnedPlanetarySystem()
    {
        planetarySystems.Clear();
    }

    /// <summary>
    /// 改变该科技对于这个文明的状态（未激活->激活；激活->未激活）
    /// </summary>
    /// <param name="technology">更新状态的科技</param>
    /// <param name="activeState">是否为激活</param>
    public void changeTechnologyActiveState(TechnologySO technology, bool activeState)
    {
        civilStatus.changeTechnologyActiveState(technology.getID(), activeState);

        if (activeState)
        {
            civilBuff.addBuff(technology.getTechnologyBuff());
        }
        else
        {
            civilBuff.removeBuff(technology.getTechnologyBuff());
        }
    }

    public void changeTechnologyUnlockedState(TechnologySO technology, bool unlockedState)
    {
        civilStatus.changeTechnologyUnlockedState(technology.getID(), unlockedState);

        if (unlockedState && playControl == false)//如果是解锁并且不是玩家文明则加入解锁栏
        {
            
        }
    }

    public void initalBasicInforDictionary()
    {
        civilBasicInfor.initialDictionary();

    }

    /// <summary>
    /// 是否为玩家控制的文明
    /// </summary>
    /// <returns>是或否</returns>
    public bool getPlayControl()
    {
        return playControl;
    }

    /// <summary>
    /// 从文明中获得特定 GameStats 的值，注意该 GameStats 必须为 int type
    /// </summary>
    /// <param name="gameStats">特定的 GameStats</param>
    /// <returns>文明关于该 GameStats的数值</returns>
    public int getGameStats_int(GameParameterSO gameStats)
    {
        return civilBasicInfor.getBasicInfor_int(gameStats) + (int) civilBuff.getAdditonalGameStats(gameStats);
    }

    /// <summary>
    /// 从文明中获得特定 GameStats 的值，注意该 GameStats 必须为 float type
    /// </summary>
    /// <param name="gameStats">特定的 GameStats</param>
    /// <returns>文明关于该 GameStats的数值</returns>
    public float getGameStats_flaot(GameParameterSO gameStats)
    {
        return civilBasicInfor.getBasicInfor_float(gameStats) + (int)civilBuff.getAdditonalGameStats(gameStats);
    }


    public CivilArchivesSO GetCivilArchives()
    {
        return civilArchives;
    }

    public CivilScienceSO GetCivilScience()
    {
        return civilScience;
    }

    public CivilStatus GetCivilStatus()
    {
        return civilStatus;
    }


}
