using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 解锁科技的条件为两种类型的科技点
/// </summary>
[CreateAssetMenu(fileName = "ActivationCost_2Type", menuName = "SO/Technology/ActiveCost/2Type")]
public class ActivationCost_2TypeSO : ActivationCostSO
{
    [SerializeField]private TechnologyPointTypeSO technologyPointType1;
    [SerializeField]private int technologyPointCost1;

    [SerializeField]private TechnologyPointTypeSO technologyPointType2;
    [SerializeField]private int technologyPointCost2;

    public override int getTechologyTypes()
    {
        return 2;
    }

    public override TechnologyPointTypeSO getTechnologyPointType(int num)
    {
        if (num == 0)
            return technologyPointType1;
        else if (num == 1)
            return technologyPointType2;
        else
            return null;
    }

    public override int getTechnologyPointCost(int num)
    {
        if (num == 0)
            return technologyPointCost1;
        else if (num == 1)
            return technologyPointCost2;
        else
            return -1;
    }
}
