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

    }

    /// <summary>
    /// 通过PlanetsFactorySo提供的方式创造行星，并将行星系设置为行星parent
    /// </summary>
    private void creatPlanets()
    {
        PlanetInfor infor = new PlanetInfor();
        infor.type = planetType[0];
        infor.fixStarPosition = fixedStar.transform.position;

        currentPlanetDistance += Random.Range(3, 5);
        infor.distance = currentPlanetDistance;

        infor.resource = Random.Range(400, 1000);
        infor.rotationSpeed = Random.Range(45,65);
        infor.revolutionSpeed = Random.Range(15, 25);

        Planet planet = planetsFactory.createPlanet(infor,stars.transform);
        planetarySystem.addPlanet(planet);
        
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
