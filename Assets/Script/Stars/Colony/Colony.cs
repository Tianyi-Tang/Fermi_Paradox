using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    [SerializeField]private CivilizationSO planetarySystemOwner;
    private bool playerCivil;

    [SerializeField] private DetectionSystem detection;

    public void occpy(CivilizationSO civilization)
    {
        if(planetarySystemOwner == null)
        {
            firstOccpy(civilization);
        }
        
    }

    private void firstOccpy(CivilizationSO civilization)
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
