using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlanetResource
{
    public int MineRate{ set; }

    public int reduceResource();
}
