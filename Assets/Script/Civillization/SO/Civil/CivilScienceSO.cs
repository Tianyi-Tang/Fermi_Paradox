using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存放用于解锁科技的 TechnologyPoint 和文明的科技等级和科技进度条
/// </summary>
[CreateAssetMenu(fileName = "CivilScience", menuName = "SO/Civilization/Civil/CivilScience")]
public class CivilScienceSO : ScriptableObject
{
    [SerializeField]private int redTechnologyPoint;
    [SerializeField]private int blueTechnologyPoint;
    [SerializeField]private int yellowTechnologyPoint;

    [SerializeField] private int scienceLevel;
    [SerializeField] private int scienceProgress; //科技研发进度
    [SerializeField] private int technologicalSingularity; //科技大爆炸

    public void increaseRedTechnologyPoint(int addTechnologyPoint)
    {
        redTechnologyPoint += addTechnologyPoint;
    }

    public void reduceRedTechnologyPoint(int reduceTechnologyPoint)
    {
        redTechnologyPoint -= reduceTechnologyPoint;
    }

    public int getRedTechnologyPoint()
    {
        return redTechnologyPoint;
    }

    public void increaseBlueTechnologyPoint(int addTechnologyPoint)
    {
        blueTechnologyPoint += addTechnologyPoint;
    }

    public void reduceBlueTechnologyPoint(int reduceTechnologyPoint)
    {
        blueTechnologyPoint -= reduceTechnologyPoint;
    }

    public int getBlueTechnologyPoint()
    {
        return blueTechnologyPoint;
    }

    public void increaseYellowTechnologyPoint(int addTechnologyPoint)
    {
        yellowTechnologyPoint += addTechnologyPoint;
    }

    public void reduceYellowTechnologyPoint(int reduceTechnologyPoint)
    {
        yellowTechnologyPoint -= reduceTechnologyPoint;
    }

    public int getYellowTechnologyPoint()
    {
        return yellowTechnologyPoint;
    }

    public void setScienceLevel(int setingScienceLevel)
    {
        scienceLevel = setingScienceLevel;
    }

    public void increaseScienceLevel()
    {
        scienceLevel++;
    }

    public int getScienceLevel()
    {
        return scienceLevel;
    }

    public void setScienceProgress(int newScienceProgress)
    {
        scienceProgress = newScienceProgress;
    }

    public int getScienceProgress()
    {
        return scienceProgress;
    }

    /// <summary>
    /// 更新文明当前的科技研发进度
    /// </summary>
    /// <param name="increaseProgress">当前增加的科技研发进度</param>
    public void addScienceProgress(int increaseProgress)
    {
        scienceProgress = scienceProgress + increaseProgress;
        ScienceLevelUp();
    }

    /// <summary>
    /// 重新设定文明的科技大爆炸的值
    /// </summary>
    /// <param name="newTechnologicalSingularity"></param>
    public void setTechnologicalSingularity(int newTechnologicalSingularity)
    {
        technologicalSingularity = newTechnologicalSingularity;
    }

    /// <summary>
    /// 获得科技大爆炸的值数
    /// </summary>
    /// <returns></returns>
    public int getTechnologicalSingularity()
    {
        return technologicalSingularity;
    }

    private void ScienceLevelUp()
    {
        if (scienceProgress >= technologicalSingularity)
            CivillizationManager.instance.scienceLevelUP(this);
    }
}
