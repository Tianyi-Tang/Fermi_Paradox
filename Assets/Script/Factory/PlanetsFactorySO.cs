using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 制作行星的工厂
/// </summary>
[CreateAssetMenu(fileName = "PlanetsFactory", menuName = "SO/Factory/PlanetsFactory")]
public class PlanetsFactorySO : ScriptableObject
{
    public List<Planet> planetPrefabs;

    public List<PlanetTypeSO> planetTypes;

    /// <summary>
    /// 根据输入的数据来创建一个行星
    /// </summary>
    /// <param name="planetType">行星的种类</param>
    /// <param name="fixedStarPosition">该行星系的恒星位置</param>
    /// <param name="distance">该行星和恒星之间的距离</param>
    /// <returns></returns>
    public Planet createPlanet(PlanetInfor infor ,Transform stars)
    {
        IPlanetInitialize planet;
        if (planetTypes[1] == infor.type)
        {
            planet = Instantiate(planetPrefabs[1]);
        }
        else
        {
            planet = Instantiate(planetPrefabs[0]);
        }

        planet.PlanetMoving.setData(infor.revolutionSpeed, infor.fixStarPosition, infor.rotationSpeed, this);
        createOrbit(infor, stars, planet);
        planet.setPlanetPos(infor.fixStarPosition, stars,infor.distance);
        return (Planet) planet;

    }

    private void createOrbit(PlanetInfor infor, Transform stars,IPlanetInitialize planet)
    {
        GameObject gol = new GameObject { name = "Circle" };
        gol.transform.position = infor.fixStarPosition;
        gol.DrawCircle(infor.distance, 0.2f, stars);
        planet.Orbit = gol.GetComponent<LineRenderer>();
    }




}
