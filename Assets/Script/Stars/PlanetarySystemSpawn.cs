using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生成行星系并设置位置
/// </summary>
public class PlanetarySystemSpawn : MonoBehaviour
{
    public PlanetarySystemFactorySO planetarySystemFactory;
    [SerializeField] private float minDistanceDifference;//两个行星系最小相距的距离
    [SerializeField] private int planetarySystemNum;

    [SerializeField] private CivilizationSpawn civilizationSpawn;
    private GameInitializeController controller;

    private List<SmallSegmentae> starsSegmentaes;
    private List<PlanetarySystem> planetarySystems = new List<PlanetarySystem>();
    public int initializationCompleteNum = 0;


    void Start()
    {
        Vector3 planetarySystemPos = new Vector3(0, 0, 0);
        for (int i = 0; i < starsSegmentaes.Count; i++)
        {
            List<Vector3> planetarySystemList = new List<Vector3>();
            for (int j = 0; j < planetarySystemNum; j++)
            {
                PlanetarySystem planetary = createPlanetarySystem(ensurePosition(planetarySystemList, planetarySystemPos, starsSegmentaes[i]), starsSegmentaes[i]);
                planetarySystems.Add(planetary);
                starsSegmentaes[i].addPlanetarySystem(planetary);
            }
        }

        StartCoroutine(activeCivilizationSpawn());

    }

    IEnumerator activeCivilizationSpawn()
    {
        
        while (initializationCompleteNum != starsSegmentaes.Count * planetarySystemNum)
            yield return null;

        controller.awakeCivilizationSpawn(planetarySystems);
        civilizationSpawn.enabled = true;
    }

    public void wakeSpanwer(List<SmallSegmentae> segmentaes, GameInitializeController controller)
    {
        if(controller != null && !this.enabled)
        {
            starsSegmentaes = segmentaes;
            this.controller = controller;
            this.enabled = true;
        }
    }

    /// <summary>
    /// 通过PlanetarySystemFactorySO提供的方式生成行星系,并将行星系添加到 civilizationSpawn
    /// </summary>
    public PlanetarySystem createPlanetarySystem(Vector3 planetarySystemPos, StarsSegmentae currentSegmentae)
    {
        int planetNum = Random.Range(1,4);
        PlanetarySystemInitialization planetarySystem = planetarySystemFactory.createPlanetarySystem(planetNum, planetarySystemPos);
        planetarySystem.transform.SetParent(currentSegmentae.transform,false);

        return planetarySystem.GetComponent<PlanetarySystem>();
    }

    /// <summary>
    /// 检查新生成的行星系的位置与其他行星系是否太过靠近
    /// </summary>
    /// <param name="planetarySystemList">储存所有行星系的list</param>
    /// <param name="planetarySystemPos">生成行星系的位置</param>
    /// <returns>两个行星系是否过于靠近</returns>
    private bool chekcDistance(List<Vector3> planetarySystemList, Vector3 planetarySystemPos)
    {

        for (int i = 0; i < planetarySystemList.Count; i++)
        {
            if (Vector3.Distance(planetarySystemList[i], planetarySystemPos) < minDistanceDifference)
                return false;
        }
        return true;
        
    }

    /// <summary>
    /// 检查行星系是否在指定星域内
    /// </summary>
    /// <param name="currentSegmentae"></param>
    /// <param name="planetarySystemPos"></param>
    /// <returns></returns>
    private bool withinTheRange(StarsSegmentae currentSegmentae, Vector3 planetarySystemPos)
    {
        if (Vector3.Distance(currentSegmentae.transform.position, planetarySystemPos) < currentSegmentae.getRadius())
            return true;
        else
            return false;
    }

    /// <summary>
    /// 确定新生成的行星系的位置
    /// </summary>
    /// <param name="planetarySystemList">储存所有行星系的list</param>
    /// <param name="planetarySystemPos">用于存储行星系位置的空变量</param>
    /// <returns>行星系的位置</returns>
    private Vector3 ensurePosition(List<Vector3> planetarySystemList, Vector3 planetarySystemPos, StarsSegmentae currentSegmentae)
    {
        float rangeValue = starsSegmentaes[0].getRadius() * 1.5f;

        while (true)
        {
            planetarySystemPos.Set(Random.Range( -rangeValue, rangeValue), Random.Range(0,4) , Random.Range(-rangeValue, rangeValue));
            if (planetarySystemList.Count > 0)
            {
                if (chekcDistance(planetarySystemList, planetarySystemPos) == true && withinTheRange(currentSegmentae, planetarySystemPos))
                {
                    planetarySystemList.Add(planetarySystemPos);
                    return planetarySystemPos;
                }       
            }
            else
            {
                if (withinTheRange(currentSegmentae, planetarySystemPos) == true)
                {
                    planetarySystemList.Add(planetarySystemPos);
                    return planetarySystemPos;
                }
            }
                

        }
        
    }

}
