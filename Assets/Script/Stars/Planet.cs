using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存行星的数据；控制行星的自转，公转和显示轨道
/// </summary>
/// <remarks>Andy 25/08/21</remarks>
public class Planet : MonoBehaviour, IPlanetInitialize,IPlanetarySystemControllable, IPlanetResource
{

    private float mass;
    private float radius; // 1 million km(real) = 1m(unity)

    [SerializeField] private LineRenderer orbit;
    [SerializeField] private PlanetMoving moving;

    [SerializeField]private PlanetTypeSO planetType;
    private List<PlanetTerraformTagSO> planetElements; //决定星球外观的数据
    private List<PlanetCorrectionTagSO> planetCorrectionTag;

    [SerializeField] private int remainResource;
    [SerializeField]private int reduceValue = 0;

    public LineRenderer Orbit { set => orbit = value; }

    public PlanetMoving PlanetMoving { get => moving; }
    public int MineRate { set => reduceValue =value; }

    public void setPlanetInfor(PlanetInfor infor)
    {
        planetType = infor.type;
        remainResource = infor.resource;
    }

    public void setPlanetPos(Vector3 fixedStar, Transform stars, float distance)
    {
        radius = distance;
        this.transform.Translate(fixedStar.x, fixedStar.y, fixedStar.z + radius);
        this.transform.parent = stars.transform;
    }

    public void setVisible(bool visible)
    {
        this.GetComponent<MeshRenderer>().enabled = visible;
        orbit.enabled = visible;
        moving.setMoving(!visible);
    }

    public void addPlanetToGetter(IPlanetGetter getter)
    {
        getter.dddPlanet(this);
    }

    public PlanetTypeSO getPlanetType()
    {
        return planetType;
    }

    public int reduceResource()
    {
        if (remainResource == 0)
            return 0;
        if(remainResource > reduceValue)
        {
            remainResource -= reduceValue;
            return reduceValue;
        }
        else
        {
            int temp = remainResource;
            remainResource = 0;
            return temp;
        }
             
    }
}
