using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CivilHabitationFactory", menuName = "SO/Factory/CivilHabitationFactory")]
public class CivilHabitationFactorySO : ScriptableObject
{
    List<PlanetTypeSO> typeSOs;

    public CivilHabitation createHabition(Planet planet)
    {
        if(planet.getPlanetType() == typeSOs[1])
        {
            return new TerrestrialPlanetHabitation(planet);
        }
        else
        {
            return new GasGiantHabitation(planet);
        }
    }

}
