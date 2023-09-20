using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 制作恒星的工厂
/// </summary>
[CreateAssetMenu(fileName = "FixedStarFactory", menuName = "SO/Factory/FixedStarFactory")]
public class FixedStarFactorySO : ScriptableObject
{
    public FixedStar fixedStar;

    public FixedStar createFixedStar()
    {
        return Instantiate(fixedStar);
    }
}
