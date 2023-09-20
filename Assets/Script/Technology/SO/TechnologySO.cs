using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 科技
/// </summary>
[CreateAssetMenu(fileName = "Technology",menuName ="SO/Technology/Technology")]
public class TechnologySO : ScriptableObject
{
    [SerializeField]private string technologyName;
    [SerializeField] private string technologyID;
    [SerializeField]private List<TechnologySO> per_Technonlogies;
    [SerializeField]private List<TechnologySO> post_Technologies;

    [SerializeField] private TechnologyTypeSO technologyType;
    [SerializeField] private ActivationCostSO activationCost;
    [SerializeField] private BuffSO technologyBuff;

    [SerializeField] private CanvasGroup canvasGroup;
    private TechnologyButton storeButton;

    public string getTechnologyName()
    {
        return technologyName;
    }

    public int getPer_TechnonlogiesNum()
    {
        return per_Technonlogies.Count;
    }

    public TechnologySO getPer_Technology(int index)
    {
        if (index > per_Technonlogies.Count)
        {
            return null;
        }
        else
        {
            return per_Technonlogies[index];
        }
    }

    public int getPost_TechnologiesNum()
    {
        return post_Technologies.Count;
    }

    public TechnologySO getPost_Technology(int index)
    {
        if (index > post_Technologies.Count)
        {
            return null;
        }
        else
        {
            return post_Technologies[index];
        }
    }

    public BuffSO getTechnologyBuff()
    {
        return technologyBuff;
    }

    public ActivationCostSO getActivationCost()
    {
        return activationCost;
    }

    public void showing()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public string getID()
    {
        return technologyID;
    }

    public void setStoreButton(TechnologyButton technologyButton)
    {
        storeButton = technologyButton;
    }

    public TechnologyButton getStoreButton()
    {
        return storeButton;
    }




}
