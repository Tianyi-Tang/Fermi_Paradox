using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存行星的数据；控制行星的自转，公转和显示轨道
/// </summary>
/// <remarks>Andy 25/08/21</remarks>
public class Planet : MonoBehaviour, IPlanetInitialize,IPlanetarySystemControllable
{

    private float mass;
    private float radius; // 1 million km(real) = 1m(unity)

    [SerializeField] private LineRenderer orbit;
    [SerializeField] private PlanetMoving moving;

    private PlanetTypeSO planetType;
    private List<PlanetTerraformTagSO> planetElements; //决定星球外观的数据
    private List<PlanetCorrectionTagSO> planetCorrectionTag;

    [SerializeField] private int remainResource;

    public LineRenderer Orbit { set => orbit = value; }

    public PlanetMoving PlanetMoving { get => moving; }

    public void setPlanetInfor(PlanetInfor infor)
    {
        planetType = infor.type;
        remainResource = infor.resource;
    }

    public void setVisible(bool visible)
    {
        this.GetComponent<MeshRenderer>().enabled = visible;
        orbit.enabled = visible;
        moving.setMoving(!visible);
    }

    public void setPlanetPos(Vector3 fixedStar, Transform stars,float distance)
    {
        radius = distance;
        this.transform.Translate(fixedStar.x, fixedStar.y, fixedStar.z + radius);
        this.transform.parent = stars.transform;
    }

    public void addPlanetToGetter(IPlanetGetter getter)
    {
        getter.dddPlanet(this);
    }

    public float getRadius()
    {
        return radius;
    }

    public void setRadius(float radius)
    {
        this.radius = radius;
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
