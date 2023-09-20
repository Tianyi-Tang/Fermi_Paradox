using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对文明的行为进行管理
/// </summary>
public class CivillizationManager : MonoBehaviour
{

    public CivilizationSpawn civilizationSpawn;

    public static CivillizationManager instance;

    private List<CivilizationSO> civilizations;
    private CivilizationSO playerCivilization;

    [SerializeField] private TechnologyPointTypeSO redTechnologyPoint;
    [SerializeField] private TechnologyPointTypeSO blueTechnologyPoint;
    [SerializeField] private TechnologyPointTypeSO yellowTechnologyPoint;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (civilizationSpawn == null)
            civilizationSpawn = GameObject.FindObjectOfType<CivilizationSpawn>();
    }

    private void Start()
    {
        TechnologyManager.TechnologyManagerInstance.OnchangingActivedState += changeTechnologyActiveState;     
    }

    /// <summary>
    /// 文明的科技等级提升，重制科技进度和增加文明的科技点
    /// </summary>
    /// <param name="civilization"></param>
    public void scienceLevelUP(CivilScienceSO civilization)
    {
        civilization.increaseScienceLevel();
        civilization.setScienceProgress(0);
    }


    public void setCivilizations(List<CivilizationSO> civillizations)
    {
        this.civilizations = civillizations;
    }

    /// <summary>
    /// 给指定的文明增加科技
    /// </summary>
    private void changeTechnologyActiveState(TechnologySO technology,CivilizationSO civilization, bool activeTechnology)
    {
        civilization.changeTechnologyActiveState(technology, activeTechnology);
    }

    public void setPlayerCivilization(CivilizationSO playerCivilization)
    {
        this.playerCivilization = playerCivilization;
    }

    public CivilizationSO getPlayerCivilization()
    {
        return playerCivilization;
    }

    /// <summary>
    /// 当文明获得一个行星系时，通知相关 script 进行改变
    /// </summary>
    /// <param name="planetarySystem"></param>
    public void addPlanetSystem(PlanetarySystem planetarySystem)
    {

    }

    /// <summary>
    /// 当文明失去一个行星系时，通知相关 script 进行改变
    /// </summary>
    /// <param name="planetarySystem"></param>
    public void deletePlanetSystem(PlanetarySystem planetarySystem)
    {

    }

}
