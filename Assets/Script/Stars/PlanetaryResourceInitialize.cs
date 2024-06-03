using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryResourceInitialize : MonoBehaviour,IPlanetGetter
{
    private HashSet<Planet> allPlanets = new HashSet<Planet>();

    public void createCollector(PlanetarySystem system)
    {
        StartCoroutine(planetsReady(system));
    }

    public void dddPlanet(Planet planet)
    {
        allPlanets.Add(planet);
    }

    IEnumerator planetsReady(PlanetarySystem system)
    {
        while (!system.allPlanetReady())
            yield return null;

        system.GetPlanets(this);
    }
}
