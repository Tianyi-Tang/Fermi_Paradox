using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : CelestialObjectMoving
{
    [SerializeField] private float revolutionSpeed;
    [SerializeField] private float revolutionRadius;
    private Vector3 fixedStarPosition;

    public override void celestialMoving() {
        base.celestialMoving();
        revolution();
    }

    private void revolution() {
        transform.RotateAround(fixedStarPosition, Vector3.up, Time.deltaTime * revolutionSpeed);
    }
}
