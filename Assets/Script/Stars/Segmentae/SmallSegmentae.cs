using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 最小的星域
/// </summary>
public class SmallSegmentae : StarsSegmentae
{
    [SerializeField] private List<PlanetarySystem> containedPlanetarySystem = new List<PlanetarySystem>();

    public void addPlanetarySystem(PlanetarySystem planetarySystem)
    {
        containedPlanetarySystem.Add(planetarySystem);
    }

    public int getPlanetarySystemNum()
    {
        return containedPlanetarySystem.Count;
    }

    public PlanetarySystem getPlanetarySystem(int index)
    {
        if (index < containedPlanetarySystem.Count)
            return containedPlanetarySystem[index];
        else
            return null;
    }

    public bool findPlanetarySystem(PlanetarySystem planetarySystem)
    {
        for(int i=0;i < containedPlanetarySystem.Count; i++)
        {
            if (planetarySystem == containedPlanetarySystem[i])
                return true;
        }
        return false;
    }
}
