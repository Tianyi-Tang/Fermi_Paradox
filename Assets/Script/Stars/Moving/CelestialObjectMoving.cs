using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObjectMoving: MonoBehaviour
{
    protected float rotationSpeed;

    public virtual void celestialMoving() {
        rotation();
    }


    protected virtual void rotation()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }
}
