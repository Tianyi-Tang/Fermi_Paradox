using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryResourceCollector : MonoBehaviour
{
    [SerializeField]private GameParameterSO mineParameter;
    private CivilizationSO civilization;
    private int civilMineRate;
    [SerializeField]private int totalResource = 0;

    private HashSet<IPlanetResource> allPlanets = new HashSet<IPlanetResource>();
    private HashSet<CivilHabitation> habitations = new HashSet<CivilHabitation>();

    private float timeInterval = 0;

    public void setCivilization(CivilizationSO civilization)
    {
        civilMineRate = civilization.getGameStats_int(mineParameter);
        if(this.civilization != null)
        {
            sendToAllHabitation();
        }
        else
        {
            GameParameterContainer.instance.getIncreaseMiningSpeed();
        }
        this.civilization = civilization;
    }

    private void Update()
    {
        if (timeInterval >= 1.0)
        {
            foreach(IPlanetResource planet in allPlanets)
            {
                totalResource += planet.reduceResource();
            }
            timeInterval = 0;
        }
        timeInterval += Time.deltaTime;
    }

    public bool Setup()
    {
        if (civilization != null && mineParameter != null)
            return true;
        else
            return false;
    }

    public void addIPlanetResource(IPlanetResource resource)
    {
        allPlanets.Add(resource);
    }

    public void addHabition(CivilHabitation habitation)
    {
        habitations.Add(habitation);
        habitation.changeCiviMineRate(civilMineRate);
    }

    private void sendToAllHabitation()
    {
        foreach (CivilHabitation habitation in habitations)
        {
            habitation.changeCiviMineRate(civilMineRate);
        }
    }
}
