using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对文明的数据进行初始化
/// </summary>
public class CivilizationSpawn : MonoBehaviour
{
    [SerializeField]private List<CivilizationSO> civilizations;

    [SerializeField] private List<TechnologySO> initialTechnologies;

    private List<Colony> planetarySystems;

    [SerializeField] private List<ShipSO> fleets;//临时测试
    
    void Start()
    { 
        main();
        CivillizationManager.instance.setCivilizations(civilizations);
    }

    /// <summary>
    /// 重置和初始化文明的所有 attribute
    /// </summary>
    private void main()
    {
        for (int i = 0; i < civilizations.Count; i++)
        {
            resetPlanetarySystem(civilizations[i]);
            initializeCivilBaseInforDictionary(civilizations[i]);
            resetScienceProgress(civilizations[i]);
            initalPlanetarySystem(civilizations[i]);
            initializationScienceLeve(civilizations[i]);
            initializePlayerInCivilManager(civilizations[i]);
            

            creatCivilState(civilizations[i]);
            initalCivilTechnology(civilizations[i]);

        }
    }

    public void wakeSpawn(List<Colony> planetarySystems,GameInitializeController controller)
    {
        if(controller != null && !this.enabled)
        {
            this.planetarySystems = planetarySystems;
            this.enabled = true;
        }
    }

    /// <summary>
    /// 初始化 文明的 CivilBasicInforSO 中储存数值的 Dictionary
    /// </summary>
    /// <param name="civilization"></param>
    private void initializeCivilBaseInforDictionary(CivilizationSO civilization)
    {
        civilization.initalBasicInforDictionary();
    }

    /// <summary>
    /// 重置文明拥有的行星系
    /// </summary>
    /// <param name="civilization">文明</param>
    private void resetPlanetarySystem(CivilizationSO civilization)
    {
        civilization.clearOwnedPlanetarySystem();
    }

    /// <summary>
    /// 重置文明的科技研发进度
    /// </summary>
    /// <param name="civilization">文明</param>
    private void resetScienceProgress(CivilizationSO civilization)
    {
        civilization.GetCivilScience().setScienceProgress(0);
    }

    /// <summary>
    /// 初始化该文明的文明特性
    /// </summary>
    /// <param name="civilization">文明</param>
    private void initializationCharacteristic(CivilizationSO civilization)
    {
        
    }

    /// <summary>
    /// 判断该文明是否被玩家控制，如果是则把该文明发送给 CivilizationManager
    /// </summary>
    /// <param name="civilization"></param>
    private void initializePlayerInCivilManager(CivilizationSO civilization)
    {
        if (playerCivilization(civilization))
            sendPlayerCivilization(civilization);
    }

    /// <summary>
    /// 初始化文明的科学等级
    /// </summary>
    /// <param name="civilization">文明</param>
    private void initializationScienceLeve(CivilizationSO civilization)
    {
        
        if (civilization.getPlayControl() == true)
            civilization.GetCivilScience().setScienceLevel(1);
    }

    /// <summary>
    /// 为文明选择初始的行星系
    /// </summary>
    /// <remarks>当前阶段暂时为随机挑选一个行星系并加入文明</remarks>
    /// <param name="civilization"></param>
    private void initalPlanetarySystem(CivilizationSO civilization)
    {
        int num = Random.Range(0, planetarySystems.Count);
        planetarySystems[num].occupy(civilization);
        planetarySystems.Remove(planetarySystems[num]);
    }

    /// <summary>
    /// 初始化文明的科技状态，将基础科技的状态设置为 unlocked
    /// </summary>
    /// <param name="civilization"></param>
    private void initalCivilTechnology(CivilizationSO civilization)
    {
        CivilStatus civilStatus = civilization.GetCivilStatus();

        for (int i = 0; i < initialTechnologies.Count; i++)
        {
            civilStatus.changeTechnologyUnlockedState(initialTechnologies[i].getID(), true);
        }
    }

    private void creatCivilState(CivilizationSO civilization)
    {
        CivilStatus civilStatus = new CivilStatus();
        civilization.setCivilStatus(civilStatus);
    }

    private bool playerCivilization(CivilizationSO civilization)
    {
        return civilization.getPlayControl();
    }

    private void sendPlayerCivilization(CivilizationSO playerCivilization)
    {
        CivillizationManager.instance.setPlayerCivilization(playerCivilization);
    }

}
