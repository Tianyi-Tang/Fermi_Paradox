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
        
    }

    private void firstOccupy(CivilizationSO civilization)
    {
        planetarySystemOwner = civilization;
        detection.setCivilzation(civilization);
        if (civilization.getPlayControl())
            DetectionManager.DetectionInstance.addPlayer_detectionSystem(detection);
        playerCivil = civilization.getPlayControl();
        
    }

    public bool getPlayerControl()
    {
        return playerCivil;
    }
}
