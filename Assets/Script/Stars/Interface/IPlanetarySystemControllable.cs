using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlanetarySystemControllable
{
    public void setVisible(bool visible);

    public void addPlanetToGetter(IPlanetGetter getter);
    
}
