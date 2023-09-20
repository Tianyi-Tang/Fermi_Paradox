using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 决定星球增减益的标签
/// </summary>
[CreateAssetMenu(fileName = "PlanetCorrectionTag", menuName = "SO/Stars/Planets/Tags/PlanetCorrectionTag")]
public class PlanetCorrectionTagSO : ScriptableObject
{
    public string correctionName;
}