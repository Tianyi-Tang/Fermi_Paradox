using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{
    private Planet currentPlanet;
    private PlanetarySystem currentPlanetarySystem;
    [SerializeField]private PlanetBuildingSO building;

    private int basic_miningSpeed;
    private int addtional_miningSpeed;

    private bool hasResource = true;
    private float passTime = 0;


    private int resource;

    void Start()
    {
        currentPlanet = this.GetComponent<Planet>();
        currentPlanetarySystem = GetComponentInParent<PlanetarySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        passTime += Time.deltaTime;
        if (passTime >= 1)
        {
            if (building != null && hasResource)
            {
                resource = currentPlanet.reduceResource(basic_miningSpeed + addtional_miningSpeed);
                if (resource != -1)
                {
                    currentPlanetarySystem.addResource(resource);
                    hasResource = false;

                }
                else
                {
                    currentPlanetarySystem.addResource(basic_miningSpeed + addtional_miningSpeed);
                }

                
            }
            passTime = 0;
        }
        

    }


    public void setBuilding(PlanetBuildingSO building)
    {
        this.building = building;
        addAddtional_miningSpeed(building.getMiningSpeed());
    }

    private void addAddtional_miningSpeed(int miningSpeed)
    {
        addtional_miningSpeed = miningSpeed;
    }
}
