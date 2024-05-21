using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存行星系的数据，并提供文明在行星系的行为
/// </summary>
public class PlanetarySystem : MonoBehaviour
{
    [SerializeField]private List<Planet> planets;
    [SerializeField]private List<LineRenderer> planetOrbits;
    [SerializeField]private FixedStar fixedStar;

    [SerializeField]private CivilizationSO planetarySystemOwner;
    private bool playControl = false;

    [SerializeField] private List<Ships> fleets;

    [SerializeField]private int civilizationResource; //文明在该行星用有的资源

    float timeInterval = 0;
    private GameParameterSO scienceDevelopment;

    private void Start()
    {
        scienceDevelopment = GameParameterContainer.instance.getScienceDevelopmentSpeed();
        starsInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInterval >= 1.0)//每一秒钟执行一次
        {
            civilizationScienceProgressIncrease();

            timeInterval = 0;
        }
        timeInterval += Time.deltaTime;
    }

    /// <summary>
    /// 隐藏的行星和轨道显现
    /// </summary>
    public void starsInvisible()
    {
        foreach (Planet planet in planets)
        {
            planet.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (LineRenderer planetOrbit in planetOrbits)
        {
            planetOrbit.enabled = false;
        }
    }

    /// <summary>
    /// 显示行星和轨道
    /// </summary>
    public void starsVisible()
    {
        foreach (Planet planet in planets)
        {
            planet.GetComponent<MeshRenderer>().enabled = true;
        }

        foreach (LineRenderer planetOrbit in planetOrbits)
        {
            planetOrbit.enabled = true;
        }
    }

    public void SetColony(Planet planet, PlanetBuildingSO planetBuilding)
    {
        Colony colony = planet.gameObject.AddComponent<Colony>();
        colony.setBuilding(planetBuilding);
    }

    /// <summary>
    /// 执行文明占领行星的行为
    /// </summary>
    /// <param name="civilization">占领行星系的文明</param>
    public void occupy(CivilizationSO civilization)
    {
        if (existCivilization())
            changeCivilization(civilization);
        else
            firstOwner(civilization);
        civilization.addNewPlanetarySystem(this);
    }


    private void changeCivilization(CivilizationSO civilization)
    {

    }


    /// <summary>
    /// 当该星系第一次被文明占领
    /// </summary>
    /// <param name="civilization"></param>
    private void firstOwner(CivilizationSO civilization)
    {
        planetarySystemOwner = civilization;
        playControl = civilization.getPlayControl();
        this.gameObject.AddComponent<DetectionSystem>();


        if (playControl == true)
            Invoke("addToDetectionManger", 0.02f);
    }

    private void addToDetectionManger()
    { 
        DetectionManager.DetectionInstance.addPlayer_detectionSystem(this.GetComponent<DetectionSystem>());
    }


    /// <summary>
    /// 如果行星系存在文明，则增加文明的科技研发进度
    /// </summary>
    private void civilizationScienceProgressIncrease()
    {
        if (existCivilization() != false)
            planetarySystemOwner.GetCivilScience().addScienceProgress( planetarySystemOwner.getGameStats_int(scienceDevelopment));
    }



    /// <summary>
    /// 判断该行星是否存在文明
    /// </summary>
    /// <returns>文明是否存在</returns>
    public bool existCivilization()
    {
        if (planetarySystemOwner != null)
            return true;
        return false;
    }

    public void addPlanetsOrbits(LineRenderer planetOrbit)
    {
        this.planetOrbits.Add(planetOrbit);
    }

    public List<Planet> GetPlanets()
    {
        return planets;
    }

    public int getPlanetsNum()
    {
        return planets.Count;
    }

    public void addPlanet(Planet planet)
    {
        planets.Add(planet);
    }

    public FixedStar getFixedStar()
    {
        return fixedStar;
    }

    public void setFixedStar(FixedStar fixedStar)
    {
        this.fixedStar = fixedStar;
    }

    public int getCivilizationResource()
    {
        return civilizationResource;
    }

    /// <summary>
    /// 该行星系是否被文明占领
    /// </summary>
    /// <returns>是/否</returns>
    public bool getPlayControl()
    {
        return playControl;
    }

    public void setFleets(List<Ships> fleets)
    {
        this.fleets = fleets;
    }

    public List<Ships> getFleets()
    {
        return fleets;
    }

    //public CivilArchivesSO getCivilArchives()
    //{
    //    if (planetarySystemOwner == null)
    //        return null;
    //    else
    //        return planetarySystemOwner.GetCivilArchives();
    //}

    public CivilizationSO getPlanetarySystemOwner()
    {
        return planetarySystemOwner;
    }

    public void addResource(int exploitedResource)
    {
        civilizationResource += exploitedResource;
    }
}
