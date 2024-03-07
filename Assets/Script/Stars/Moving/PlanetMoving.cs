using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : CelestialObjectMoving
{
    [SerializeField] private float revolutionSpeed;
    [SerializeField] private float revolutionRadius;
    private Vector3 fixedStarPosition;

    public void passpassParameter(float rotationSpeed,float revolutionSpeed,float revolutionRadius)
    {
        this.rotationSpeed = rotationSpeed;
        this.revolutionSpeed = revolutionSpeed;
        this.revolutionRadius = revolutionRadius;
    }

    private void revolution() {
        transform.RotateAround(fixedStarPosition, Vector3.up, Time.deltaTime * revolutionSpeed);
    }

    protected override void Update()
    {
        base.Update();
        revolution();
    }
}
