using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    [SerializeField]private CivilizationSO planetarySystemOwner;
    private bool playerCivil;

    [SerializeField] private DetectionSystem detection;
    private PlanetarySystem system;

    private void Start()
    {
        system = gameObject.GetComponent<PlanetarySystem>();   
    }

    public void occupy(CivilizationSO civilization)
    {
        if(planetarySystemOwner == null)
        {
            firstOccupy(civilization);
        }
        planetarySystemOwner = civilization;
        detection.setCivilzation(civilization);
    }

    private void firstOccupy(CivilizationSO civilization)
    {
        playerCivil = civilization.getPlayControl();
        if (playerCivil)
            DetectionManager.DetectionInstance.addPlayer_detectionSystem(detection);

        gameObject.GetComponent<PlanetaryResourceInitialize>().createCollector(system, civilization);
    }

    public CivilizationSO getPlanetarySystemOwner()
    {
        return planetarySystemOwner;
    }

    public bool getPlayerControl()
    {
        return playerCivil;
    }
}
