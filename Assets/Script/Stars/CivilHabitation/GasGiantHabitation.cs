using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasGiantHabitation : CivilHabitation
{
    public GasGiantHabitation(Planet planet)
    {
        this.planet = planet;
    }

    static float mineAdvase = 1.0f;

    protected override void recalcuate()
    {
       finallMineRate = civilMineRate + mineAdvase;
    }

}
