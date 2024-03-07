using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : CelestialObjectMoving
{
    [SerializeField] private float revolutionSpeed;
    [SerializeField] private float revolutionRadius;
    private Vector3 fixedStarPosition;

    public void passpassParameter(float rotationSpeed,float revolutionSpeed,float revolutionRadius,Vector3 fixedStarPosition)
    {
        this.rotationSpeed = rotationSpeed;
        this.revolutionSpeed = revolutionSpeed;
        this.revolutionRadius = revolutionRadius;
        this.fixedStarPosition = fixedStarPosition;
        getInfor = true;
    }

    public LineRenderer createOrbit(Transform planetSystem) {
        GameObject gol = new GameObject { name = "Circle" };
        gol.transform.position = fixedStarPosition;
        gol.DrawCircle(revolutionRadius, 0.2f, planetSystem);
        return gol.GetComponent<LineRenderer>();
    }

    private void revolution() {
        transform.RotateAround(fixedStarPosition, Vector3.up, Time.deltaTime * revolutionSpeed);
    }

    protected override void Update()
    {
        if (getInfor)
        {
            revolution();
            revolution();
        }
        
    }
}
