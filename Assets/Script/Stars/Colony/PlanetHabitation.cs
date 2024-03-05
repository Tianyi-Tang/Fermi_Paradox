using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlanetHabitation
{
    public void receiveMineRate(int mineRate);
    public List<PlanetBuildingSO> getsuitableBuilding();
    public bool switchBuilding(PlanetBuildingSO building);
    public bool changePolicy();
}
