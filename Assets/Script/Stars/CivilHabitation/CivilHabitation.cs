using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CivilHabitation 
{
    protected IPlanetResource planet;

    protected int civilMineRate;

    protected int finallMineRate;


    public void changeCiviMineRate(int mineRate)
    {
        civilMineRate = mineRate;
        recalcuate();
    }

    protected virtual void recalcuate()
    {
        finallMineRate = civilMineRate;
        sendToPlanet();
    }

    protected void sendToPlanet()
    {
        planet.MineRate = finallMineRate;
    }

}
