using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlanetaryStarFactory
{
    public Planet createPlanetarySystem();
    public FixedStar createFixedStar();
}
