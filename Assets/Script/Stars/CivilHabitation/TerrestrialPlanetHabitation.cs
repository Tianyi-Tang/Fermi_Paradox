using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrestrialPlanetHabitation : CivilHabitation
{
    static float mineDisadv = -1.0f;

    protected override void recalcuate()
    {
        finallMineRate = civilMineRate + mineDisadv;
    }
}
