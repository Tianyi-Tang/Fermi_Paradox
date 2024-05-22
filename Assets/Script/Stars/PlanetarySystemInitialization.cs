using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 初始化行星系的脚本，负责创造行星和恒星
/// </summary>
public class PlanetarySystemInitialization : MonoBehaviour
{
    public PlanetarySystem planetarySystem;

    public int planetNum;
    private float currentPlanetDistance =0;
    private int planetOrbitNum = 0;

    public PlanetsFactorySO planetsFactory;
    public FixedStarFactorySO fixedStarFactory;

    [SerializeField] private GameObject stars; //所有恒星与行星的父物体

    public List<PlanetTypeSO> planetType; //气态行星或类地行星
    public List<PlanetTerraformTagSO> planetElements;
    public List<PlanetCorrectionTagSO> planetTags;

    private FixedStar fixedStar;


    private void Awake()
    {
        creatFixedStar();
        
    }

    private void Start()
    {
        for (int i = 0; i < planetNum; i++)
        {
            creatPlanets();
            planetOrbitNum++;
        }
        FindObjectOfType<PlanetarySystemSpawn>().initializationCompleteNum += 1;

        //addAllPlanetOrbits();
    }

    /// <summary>
    /// 将该行星系的所有星球轨道添加到 planetarySystem 中
    /// </summary>
    private void addAllPlanetOrbits()
    {
        for (int i = 0; i < stars.transform.childCount; i++)
        {
            LineRenderer orbit = stars.transform.GetChild(i).GetComponent<LineRenderer>();
            if (orbit != null)
                planetarySystem.addPlanetsOrbits(orbit);
        }
    }

    /// <summary>
    /// 通过PlanetsFactorySo提供的方式创造行星，并将行星系设置为行星parent
    /// </summary>
    private void creatPlanets()
    {
        currentPlanetDistance += Random.Range(3, 5);
        int resuorec = Random.Range(400, 1000);
        Planet planet = planetsFactory.createPlanet(planetType[0],planetarySystem.getFixedStar().transform.position,currentPlanetDistance, stars.transform, resuorec);
        planetarySystem.addPlanet(planet);
        createOrbit(currentPlanetDistance);
    }

    private void createOrbit(float distanceBetweenFixedStar)
    {
        GameObject gol = new GameObject { name = "Circle" };
        gol.transform.position = fixedStar.transform.position;
        gol.DrawCircle(distanceBetweenFixedStar, 0.2f, stars.transform);
        planetarySystem.addPlanetsOrbits(gol.GetComponent<LineRenderer>());
        gol.GetComponent<LineRenderer>().enabled = false;

    }

    /// <summary>
    /// 通过FixedStarFactorySo提供的方式创造行星，并将行星系设置为恒星parent
    /// </summary>
    private void creatFixedStar()
    {
        fixedStar = fixedStarFactory.createFixedStar();
        fixedStar.transform.parent = stars.transform;
        fixedStar.transform.position = transform.position;
        planetarySystem.setFixedStar(fixedStar);
    }

}
