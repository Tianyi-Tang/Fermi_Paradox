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
    public Planet createPlanet(PlanetTypeSO planetType,Vector3 fixedStarPosition, float distance, Transform stars, int planetResource)
    {
        Planet planet;
        if (planetTypes[1] == planetType)
        {
            initializationAttribute(planetPrefabs[1], fixedStarPosition, distance, planetType,stars, planetResource);
            planet =  Instantiate(planetPrefabs[1]);
        }
        else
        {
            initializationAttribute(planetPrefabs[0], fixedStarPosition, distance, planetType,stars, planetResource);
            planet = Instantiate(planetPrefabs[0]);
        }

        planet.transform.Translate(fixedStarPosition.x, fixedStarPosition.y, fixedStarPosition.z + distance);
        planet.transform.parent = stars.transform;

        return planet;


    }


    /// <summary>
    /// 初始化行星的数据
    /// </summary>
    /// <param name="planet">行星自身的reference</param>
    /// <param name="fixedStarPosition">恒星的位置</param>
    /// <param name="distance">该行星和恒星之间的距离</param>
    /// <param name="planetType">行星的种类</param>
    private void initializationAttribute(Planet planet,Vector3 fixedStarPosition, float distance, PlanetTypeSO planetType,Transform stars, int planetResource)
    {
        planet.fixedStarPosition = fixedStarPosition;
        planet.distanceBetweenFixedStar = distance;
        planet.planetType = planetType;
        planet.parent = stars;

        planet.setRemainResourec(planetResource);
    }

     

}
