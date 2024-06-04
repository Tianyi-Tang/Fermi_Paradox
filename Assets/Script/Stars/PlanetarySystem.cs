using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存行星系的数据，并提供文明在行星系的行为
/// </summary>
public class PlanetarySystem : MonoBehaviour
{
    [SerializeField]private List<IPlanetarySystemControllable> planets = new List<IPlanetarySystemControllable>();
    [SerializeField]private FixedStar fixedStar;

    private int planetNum = 0;

    [SerializeField] private List<Ships> fleets;

    /// <summary>
    /// 隐藏的行星和轨道显现
    /// </summary>
    public void starsInvisible()
    {
        foreach (IPlanetarySystemControllable planet in planets)
        {
            planet.setVisible(false);
        }
    }

    /// <summary>
    /// 显示行星和轨道
    /// </summary>
    public void starsVisible()
    {
        foreach (IPlanetarySystemControllable planet in planets)
        {
            planet.setVisible(true);
        }
    }

    public bool allPlanetReady()
    {
        if (planets.Count == planetNum)
            return true;
        else
            return false;
    }

    public void setPlanetsNum(int num)
    {
        if (planetNum == 0)
            planetNum = num;
    }

    public void GetPlanets(IPlanetGetter getter)
    {
        foreach (IPlanetarySystemControllable planet in planets)
        {
            planet.addPlanetToGetter(getter);
        }
    }

    public int getPlanetsNum()
    {
        return planetNum;
    }

    public void addPlanet(IPlanetarySystemControllable planet)
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


    public void setFleets(List<Ships> fleets)
    {
        this.fleets = fleets;
    }

    public List<Ships> getFleets()
    {
        return fleets;
    }


    ///// <summary>
    ///// 如果行星系存在文明，则增加文明的科技研发进度
    ///// </summary>
    //private void civilizationScienceProgressIncrease()
    //{
    //    if (existCivilization() != false)
    //        planetarySystemOwner.GetCivilScience().addScienceProgress( planetarySystemOwner.getGameStats_int(scienceDevelopment));
    //}






}
