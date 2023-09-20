using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 快速访问文明的科技，词条，等解锁状态
/// </summary>
public class CivilStatus
{
    private Dictionary<string, TechnologyState> technologyStates;//存储所有文明解锁的科技


    public CivilStatus()
    {
        technologyStates = new Dictionary<string, TechnologyState>();
        List<TechnologySO> technologies = TechnologyManager.TechnologyManagerInstance.getAllTechnologies();
        initizationTechnologyStates(technologies);
    }

    /// <summary>
    /// 初始化科技状态
    /// </summary>
    /// <param name="technologies"></param>
    private void initizationTechnologyStates(List<TechnologySO> technologies )
    {
        int num = technologies.Count;

        for (int i = 0; i < num; i++)
        {
            technologyStates.Add(technologies[i].getID(), new TechnologyState());
        }
    }

    /// <summary>
    /// 查看文明是否激活该科技
    /// </summary>
    /// <param name="technologyID">科技的ID</param>
    /// <returns>如果解锁 return true，否则 return false</returns>
    public bool viewTechnologyActiveState(string technologyID)
    {
        return technologyStates[technologyID].getActiveState();
    }

    /// <summary>
    /// 查看文明是解锁该科技
    /// </summary>
    /// <param name="technologyID">科技的ID</param>
    /// <returns></returns>
    public bool viewTechnologyUnlockedState(string technologyID)
    {
        return technologyStates[technologyID].getUnlockedState();
    }

    /// <summary>
    /// 对特定科技的激活状态进行更改
    /// </summary>
    /// <param name="technologyID">科技的ID</param>
    /// <param name="activeState">是否要激活该科技</param>
    /// <returns>如果ID能找到对应的科技 return true，如果不能return false </returns>
    public bool changeTechnologyActiveState(string technologyID, bool activeState)
    {
        TechnologyState technologyState = technologyStates[technologyID];
        if (technologyState == null)
            return false;

        if (activeState == true)
            technologyState.activeTechnology();
        else
            technologyState.deactiveTechnology();
        return true;
    }

    /// <summary>
    /// 对特定科技的解锁状态进行更改
    /// </summary>
    /// <param name="technologyID">科技的ID</param>
    /// <param name="unlockedState">是否要解锁该科技</param>
    /// <returns>如果ID能找到对应的科技 return true，如果不能return false</returns>
    public bool changeTechnologyUnlockedState(string technologyID, bool unlockedState)
    {
        if (technologyStates[technologyID] == null)
            return false;

        if (unlockedState == true)
            technologyStates[technologyID].unlockedTechnology();
        else
            technologyStates[technologyID].lockedTechnology();

        return true;
    }



}
