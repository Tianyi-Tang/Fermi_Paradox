using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasGiantHabitation : CivilHabitation
{
    public GasGiantHabitation(Planet planet)
    {
        this.planet = planet;
    }

    static int mineAdvase = 1;

    protected override void recalcuate()
    {
       finallMineRate = civilMineRate + mineAdvase;
    }

}
