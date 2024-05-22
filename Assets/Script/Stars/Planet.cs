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

    void Update()
    {
        revolution();
        rotation();
    }

    /// <summary>
    /// 实现行星的公转
    /// </summary>
    private void revolution()
    {
        transform.RotateAround(fixedStarPosition, Vector3.up, Time.deltaTime * revolutionSpeed);
    }

    /// <summary>
    /// 实现星球的自转
    /// </summary>
    private void rotation()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }

    ///// <summary>
    ///// 展现星球的运行轨道
    ///// </summary>
    //private void creatOrbit()
    //{
    //    GameObject gol = new GameObject { name = "Circle" };
    //    gol.transform.position = fixedStarPosition;
    //    gol.DrawCircle(distanceBetweenFixedStar, 0.2f, parent);
    //    orbit = gol.GetComponent<LineRenderer>();
    //}

    ///// <summary>
    ///// 根据恒星的位置和与恒星的距离来改变星球的位置
    ///// </summary>
    //private void changePosition()
    //{
    //    transform.Translate(fixedStarPosition.x, fixedStarPosition.y, fixedStarPosition.z + distanceBetweenFixedStar);
    //}

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
