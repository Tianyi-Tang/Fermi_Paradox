using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetarySystemFactory", menuName = "SO/Factory/PlanetarySystemFactory")]
public class PlanetarySystemFactorySO : ScriptableObject
{
    [SerializeField]private PlanetarySystemInitialization planetarySystemInitialization;

    public PlanetarySystemInitialization createPlanetarySystem(int planetNum, Vector3 planetarySystemPos)
    {
        initializationAttribute(planetNum, planetarySystemPos);
        return Instantiate(planetarySystemInitialization);
    }

    public void initializationAttribute(int planetNum,Vector3 planetarySystemPos)
    {
        planetarySystemInitialization.planetNum = planetNum;
        planetarySystemInitialization.transform.position = planetarySystemPos;
        
    }
}
