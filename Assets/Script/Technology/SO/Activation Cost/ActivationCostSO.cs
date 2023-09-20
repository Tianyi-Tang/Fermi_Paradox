using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作为所有 ActivationCost的父类
/// </summary>
public class ActivationCostSO : ScriptableObject
{
    protected int TechologyTypes;//有几个不同种类的科技点

    public virtual int getTechologyTypes()
    {
        return TechologyTypes;
    }

    public virtual TechnologyPointTypeSO getTechnologyPointType(int num)
    {
        return null;
    }

    public virtual int getTechnologyPointCost(int num)
    {
        return -1;
    }
    
}
