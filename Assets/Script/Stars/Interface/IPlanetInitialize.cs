using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlanetInitialize 
{
    public LineRenderer Orbit { set; }

    public PlanetMoving PlanetMoving { get; }

    public void setPlanetInfor(PlanetInfor infor);
}
