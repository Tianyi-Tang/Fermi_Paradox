using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解锁科技的条件为一种类型的科技点
/// </summary>
[CreateAssetMenu(fileName = "ActivationCost_1Type",menuName ="SO/Technology/ActiveCost/1Type")]
public class ActivationCost_1TypeSO : ActivationCostSO
{
    [SerializeField]private TechnologyPointTypeSO technologyPointType1;
    [SerializeField]private int technologyPointCost1;

    public override int getTechologyTypes()
    {
        return 1;
    }

    public override TechnologyPointTypeSO getTechnologyPointType(int num)
    {
        if (num == 0)
            return technologyPointType1;
        else
            return null;
    }

    public override int getTechnologyPointCost(int num)
    {
        if (num == 0)
            return technologyPointCost1;
        else
            return -1;
    }
}
