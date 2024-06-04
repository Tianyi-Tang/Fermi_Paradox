using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrestrialPlanetHabitation : CivilHabitation
{
    static int mineAdvase = 1;

    public TerrestrialPlanetHabitation(IPlanetResource planet)
    {
        this.planet = planet;
    }

    protected override void recalcuate()
    {
        finallMineRate = civilMineRate + mineAdvase;
        sendToPlanet();
    }
}
