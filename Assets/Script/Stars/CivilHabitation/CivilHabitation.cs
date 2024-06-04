using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CivilHabitation 
{
    protected Planet planet;

    protected float civilMineRate;

    protected float finallMineRate;


    public void changeCiviMineRate(float mineRate)
    {
        civilMineRate = mineRate;
        recalcuate();
    }

    public void setBasicInfor(Planet planet, float mineRate)
    {
        if (planet == null)
        {
            this.planet = planet;
            civilMineRate = mineRate;
        }

    }

    protected virtual void recalcuate()
    {
        finallMineRate = civilMineRate;
    }

}
