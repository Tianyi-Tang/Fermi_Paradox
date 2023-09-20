using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetBuilding", menuName = "SO/Stars/Building/PlanetBuilding")]
public class PlanetBuildingSO : ScriptableObject
{
    [SerializeField]private string buildingName;
    [SerializeField] private string describtiion;

    [SerializeField] private int miningSpeed;
    [SerializeField] private int energyConsuming;

    public int getMiningSpeed()
    {
        return miningSpeed;
    }

}
