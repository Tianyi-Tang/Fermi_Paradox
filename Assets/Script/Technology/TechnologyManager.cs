using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// 存放并管理所有科技的class
/// </summary>
public class TechnologyManager : MonoBehaviour
{
    public static TechnologyManager TechnologyManagerInstance;

    private TechnologySO selectedTecnology;

    [SerializeField]private List<TechnologyPointTypeSO> technologyPointTypes;

    [SerializeField]private List<TechnologySO> allTechnologies;

    public event Action<TechnologySO, CivilizationSO ,bool> OnchangingActivedState;
    

    void Start()
    {
        TechnologyManagerInstance = this;
    }

    public void setSelectedTecnology(TechnologyButton technologyButton)
    {
        selectedTecnology = technologyButton.getTechnology();
        activeTechnology(CivillizationManager.instance.getPlayerCivilization(),true);
    }

    /// <summary>
    /// 激活对应文明的科技
    /// </summary>
    /// <param name="civilization">文明</param>
    /// <param name="playerCivil">是否是玩家的文明</param>
    private void activeTechnology(CivilizationSO civilization, bool playerCivil)
    {
        OnchangingActivedState(selectedTecnology, civilization, true);

        updateTechnologyUI(civilization, playerCivil);
        reduceTecnologyPoint(civilization.GetCivilScience());
    }

    private void reduceTecnologyPoint(CivilScienceSO civilScience)
    {
        ActivationCostSO activationCost = selectedTecnology.getActivationCost();
        int numOfTechonlogyPoint = activationCost.getTechologyTypes();

        for (int i = 0; i < numOfTechonlogyPoint; i++)
        {
            if (technologyPointTypes[0] == activationCost.getTechnologyPointType(i))
                civilScience.reduceRedTechnologyPoint(activationCost.getTechnologyPointCost(i));
            else if (technologyPointTypes[1] == activationCost.getTechnologyPointType(i))
                civilScience.reduceBlueTechnologyPoint(activationCost.getTechnologyPointCost(i));
            else
                civilScience.reduceYellowTechnologyPoint(activationCost.getTechnologyPointCost(i));
        }
    }

    /// <summary>
    /// 当被选择的科技激活时，显示被解锁的其他科技
    /// </summary>
    private void updateTechnologyUI(CivilizationSO civilStatus, bool playerCivil)
    {
        for (int i = 0; i < selectedTecnology.getPost_TechnologiesNum(); i++)
        {
            unlockedTechnology(selectedTecnology.getPost_Technology(i), civilStatus,playerCivil);
        }
    }

    /// <summary>
    /// 判断科技是否达成解锁条件
    /// </summary>
    /// <param name="technology">被判断是否解锁的科技</param>
    private void unlockedTechnology(TechnologySO technology, CivilizationSO civilization,bool playerCivil)
    {
        int index = technology.getPer_TechnonlogiesNum();
        bool successUnlocked = true;

        for (int i = 0; i < index; i++)
        {
            if (civilization.GetCivilStatus().viewTechnologyActiveState(technology.getPer_Technology(i).getID()) == false)
                successUnlocked = false;
        }

        if (successUnlocked == true)
        {
            civilization.changeTechnologyUnlockedState(technology, true);
            if (playerCivil)
                showingTechnology(technology);
        }
            
    }

    private void showingTechnology(TechnologySO technology)
    {
        technology.getStoreButton().show();
    }

    public List<TechnologySO> getAllTechnologies()
    {
        return allTechnologies;
    }



}
