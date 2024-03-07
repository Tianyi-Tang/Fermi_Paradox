using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObjectMoving: MonoBehaviour
{
    protected float rotationSpeed;
    protected bool getInfor = false;

    public virtual void passParameter(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
        getInfor = true;
    }

    protected virtual void rotation()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }

    protected virtual void Update()
    {
        if (getInfor)
        {
            rotation();
        }
        
    }
}
