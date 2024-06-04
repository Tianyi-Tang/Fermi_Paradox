using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryResourceInitialize : MonoBehaviour,IPlanetGetter
{
    [SerializeField] private CivilHabitationFactorySO factory;
    PlanetaryResourceCollector collector;

    public void createCollector(PlanetarySystem system,CivilizationSO civilization)
    {
        collector = gameObject.AddComponent<PlanetaryResourceCollector>();
        collector.setCivilization(civilization);
        StartCoroutine(planetsReady(system,collector));
    }

    public void dddPlanet(Planet planet)
    {
        collector.addHabition(factory.createHabition(planet));
        collector.addIPlanetResource(planet);
    }

    IEnumerator planetsReady(PlanetarySystem system, PlanetaryResourceCollector collector)
    {
        while (!system.allPlanetReady() && collector.Setup())
            yield return null;

        system.GetPlanets(this);
    }
}
