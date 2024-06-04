using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrestrialPlanetHabitation : CivilHabitation
{
    static float mineDisadv = -1.0f;

    public TerrestrialPlanetHabitation(Planet planet)
    {
        this.planet = planet;
    }

    protected override void recalcuate()
    {
        finallMineRate = civilMineRate + mineDisadv;
    }
}
