using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : CelestialObjectMoving
{
    protected float rotationSpeed;

    public void setData(float revolutionSpeed, Vector3 fixedStarPos,float rotationSpeed, PlanetsFactorySO factory)
    {
        if(factory != null && !allDataSet)
        {
            base.setData(revolutionSpeed, fixedStarPos, factory);
            this.rotationSpeed = rotationSpeed;
        }
        
    }

    private void Update()
    {
        if (allDataSet)
        {
            revolution();
            rotation();
        }
    }

    /// <summary>
    /// 实现星球的自转
    /// </summary>
    private void rotation()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }


}
