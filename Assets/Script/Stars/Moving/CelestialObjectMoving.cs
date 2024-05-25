using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObjectMoving : MonoBehaviour
{
    protected float revolutionSpeed;
    protected Vector3 fixedStarPos;

    protected bool allDataSet = false;


    public void setData(float revolutionSpeed, Vector3 fixedStarPos, PlanetsFactorySO factory)
    {
        if(factory != null && !allDataSet)
        {
            this.revolutionSpeed = revolutionSpeed;
            this.fixedStarPos = fixedStarPos;
            allDataSet = true;
        }
    }

    private void Update()
    {
        if (allDataSet)
            revolution();
    }

    /// <summary>
    /// 实现行星的公转
    /// </summary>
    protected void revolution()
    {
        transform.RotateAround(fixedStarPos, Vector3.up, Time.deltaTime * revolutionSpeed);
    }

}
