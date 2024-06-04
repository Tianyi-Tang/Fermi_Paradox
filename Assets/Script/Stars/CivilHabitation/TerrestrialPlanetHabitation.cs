using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrestrialPlanetHabitation : CivilHabitation
{
    static int mineDisadv = -1;

    public TerrestrialPlanetHabitation(Planet planet)
    {
        this.planet = planet;
    }

    protected override void recalcuate()
    {
        finallMineRate = civilMineRate + mineDisadv;
    }
}
