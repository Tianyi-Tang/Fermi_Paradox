using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存行星的数据；控制行星的自转，公转和显示轨道
/// </summary>
/// <remarks>Andy 25/08/21</remarks>
public class Planet : MonoBehaviour
{

    private float mass;
    private float radius; // 1 million km(real) = 1m(unity)
    [SerializeField]private float revolutionSpeed;
    public float rotationSpeed;

    public Vector3 fixedStarPosition;
    public float distanceBetweenFixedStar; // 1 million km(real) = 1m(unity)
    [SerializeField]private LineRenderer orbit;

    public PlanetTypeSO planetType;
    public List<PlanetTerraformTagSO> planetElements; //决定星球外观的数据
    public List<PlanetCorrectionTagSO> planetCorrectionTag;

    [SerializeField]private int remainResource;

    public Transform parent;

    private void Awake()
    {

    }
   

    public float getMass()
    {
        return mass;
    }

    public void setMass(float mass)
    {
        this.mass = mass;
    }

    public float getRadius()
    {
        return radius;
    }

    public void setRadius(float radius)
    {
        this.radius = radius;
    }

    public void setRevolutionSpeed(float revolutionSpeed)
    {
        this.revolutionSpeed = revolutionSpeed;
    }

    public void setRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }

    public int reduceResource(int exploitedResource)
    {
        remainResource -= exploitedResource;

        if (remainResource > 0)
            return -1;
        else
            return Mathf.Abs(remainResource);
            
    }

    public float getRemainResource()
    {
        return remainResource;
    }

    public void setRemainResourec(int intialResourec)
    {
        remainResource = intialResourec;
    }

   
}
