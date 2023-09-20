using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解锁科技的条件为三种类型的科技点
/// </summary>
[CreateAssetMenu(fileName = "ActivationCost_3Type",menuName = "SO/Technology/ActiveCost/3Type")]
public class ActivationCost_3TypeSO : ActivationCostSO
{
    [SerializeField] private TechnologyPointTypeSO technologyPointType1;
    [SerializeField] private int technologyPointCost1;

    [SerializeField] private TechnologyPointTypeSO technologyPointType2;
    [SerializeField] private int technologyPointCost2;

    [SerializeField] private TechnologyPointTypeSO technologyPointType3;
    [SerializeField] private int technologyPointCost3;

    public override int getTechologyTypes()
    {
        return 3;
    }

    public override TechnologyPointTypeSO getTechnologyPointType(int num)
    {
        if (num == 0)
            return technologyPointType1;
        else if (num == 1)
            return technologyPointType2;
        else if (num == 2)
            return technologyPointType3;
        else
            return null;
    }

    public override int getTechnologyPointCost(int num)
    {
        if (num == 0)
            return technologyPointCost1;
        else if (num == 1)
            return technologyPointCost2;
        else if (num == 2)
            return technologyPointCost3;
        else
            return -1;
    }

}
