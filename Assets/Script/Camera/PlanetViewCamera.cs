using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 照射行星的相机
/// </summary>
public class PlanetViewCamera : MonoBehaviour
{
    private Planet planet;
    private Vector3 planetPos;
    private const float offsetZ = -1.49f;


    public void setPlanet(Planet planet)
    {
        this.planet = planet;
    }

    // Update is called once per frame
    void Update()
    {
        if (planet != null)
        {
            planetPos = planet.transform.position;
            planetPos.z += offsetZ;
            transform.position = planetPos;
        }
    }
}
