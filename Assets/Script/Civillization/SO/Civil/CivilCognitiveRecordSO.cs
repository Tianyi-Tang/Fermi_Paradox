using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 包含文明需要解锁科技的科技点（Technology Point）和所有已解锁的科技
/// </summary>
[CreateAssetMenu(fileName = "CivilCognitiveRecord", menuName = "SO/Civilization/Civil/CivilCognitiveRecord")]
public class CivilCognitiveRecordSO: ScriptableObject
{
    private List<TechnologySO> spacecraftTechnologies;
    private List<TechnologySO> detectionTechnologies;
    private List<TechnologySO> anti_DetectionTechnologies;

    public void addNewdetectionTechnology(TechnologySO technology)
    {
        detectionTechnologies.Add(technology);
    }
}
