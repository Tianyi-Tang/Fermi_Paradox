using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrestrialPlanetHabitation : MonoBehaviour,PlanetHabitation
{
    int basicMineRate;
    [SerializeField]private List<PlanetBuildingSO> buildings;
    private PlanetBuildingSO currentBuilding;

   
     public List<PlanetBuildingSO> getsuitableBuilding()
    {
        return buildings;
    }

    public void receiveMineRate(int mineRate)
    {
        basicMineRate = mineRate;
    }

    public bool switchBuilding(PlanetBuildingSO building)
    {
        currentBuilding = building;
        return true;
    }

    public bool changePolicy()
    {
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
