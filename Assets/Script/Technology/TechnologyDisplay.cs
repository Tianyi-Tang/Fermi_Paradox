using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 显示科技的名字，介绍，和解锁条件
/// </summary>
public class TechnologyDisplay : MonoBehaviour
{
    public static TechnologyDisplay DisplayInstance;

    private TechnologyButton currentTechnologyButton;
    private TechnologySO currentDisplayTecnology;
    
    private ActivationCostSO currentActiveCost;

    [SerializeField] private CanvasGroup infoPanel;
    private bool infoPanelShowing = false;

    [SerializeField]private Text tecnologyName;
    [SerializeField] private CanvasGroup activeTechnologyButton;
    private Image buttonImage;

    private Color specificBlack;

    [SerializeField] private CanvasGroup activeCostTemplate1;
    [SerializeField] private CanvasGroup activeCostTemplate2;
    [SerializeField] private CanvasGroup activeCostTemplate3;
    private Transform currentAvtiveTemplate;

    [SerializeField] private TechnologyPointTypeSO redTechnologyPoint;
    [SerializeField] private TechnologyPointTypeSO blueTechnologyPoint;
    [SerializeField] private TechnologyPointTypeSO yellowTechnologyPoint;

    

    private void Start()
    {
        buttonImage = activeTechnologyButton.GetComponent<Image>();
        DisplayInstance = this;
        creatspecificBlack();
    }

    public void displayTechnology(TechnologyButton technologyButton)
    {
        currentTechnologyButton = technologyButton;
        currentDisplayTecnology = technologyButton.getTechnology();

        currentActiveCost = currentDisplayTecnology.getActivationCost();

        setTextInfor();
        controlButtonDisplaying();

        if (infoPanelShowing == false)
            activePanel();
        else
            disactiveTemplate();

        activeCostDisplay();
    }

    private void setTextInfor()
    {
        tecnologyName.text = currentDisplayTecnology.getTechnologyName();
    }

    private void activeCostDisplay()
    {
        int technologiesTypeNum = displayTemplate();
        for (int i = 0; i < technologiesTypeNum; i++)
        {
            setActiveCostTemplate(i);
        }
            
    }

    private void setActiveCostTemplate(int childNum)
    {
        Transform templateChild = currentAvtiveTemplate.GetChild(childNum);
        Color color = conformColor(getAvtiveTechnologyType(childNum));

        setTemplateImageColor(templateChild.GetChild(0).GetComponent<Image>(), color);
        setTemplateText(templateChild.GetComponent<Text>(), getAvtiveTechnologyPointCost(childNum).ToString());
    }

    /// <summary>
    /// 根据 ActiveCost 显示 template
    /// </summary>
    /// <returns>有几个 TechologyPoint 需要显示</returns>
    private int displayTemplate()
    {
        int num = currentActiveCost.getTechologyTypes();
        CanvasGroup template;
        if (num == 1)
            template = activeCostTemplate1;
        else if (num == 2)
            template = activeCostTemplate2;
        else
            template = activeCostTemplate3;

        currentAvtiveTemplate = template.GetComponent<Transform>();
        template.alpha = 1;

        return num;
    }

    private void activePanel()
    {
        infoPanelShowing = true;

        infoPanel.alpha = 1;
        infoPanel.blocksRaycasts = true;
    }

    public void disactivePanel()
    {
        infoPanelShowing = false;

        infoPanel.alpha = 0;
        infoPanel.blocksRaycasts = false;
        disactiveTemplate();
    }

    private void disactiveTemplate()
    {
        if(currentAvtiveTemplate != null)
            currentAvtiveTemplate.GetComponent<CanvasGroup>().alpha = 0;
    }

    private void setTemplateImageColor(Image image, Color color)
    {
        image.color = color;
    }

    private void setTemplateText(Text cost, string costNum)
    {
        cost.text = costNum;
    }

    private Color conformColor(TechnologyPointTypeSO technologyPoint)
    {
        if (technologyPoint == redTechnologyPoint)
            return Color.red;
        else if (technologyPoint == blueTechnologyPoint)
            return Color.blue;
        else if (technologyPoint == yellowTechnologyPoint)
            return Color.yellow;
        else
            return Color.white;
    }

    /// <summary>
    /// 查看玩家的文明是否符合激活 currentTechnology 的条件，如果符合则让 button可被点击
    /// </summary>
    private void controlButtonDisplaying()
    {
        int num = currentActiveCost.getTechologyTypes();
        bool engoughResources = true;

        for (int i = 0; i < num; i++)
        {
            if (enoughTechnologyPoint(getAvtiveTechnologyPointCost(i), getAvtiveTechnologyType(i)) == false)
            {
                engoughResources = false;
                break;
            }
                
        }

        if (engoughResources && currentTechnologyButton.getActiveState() == false)
        {
            activeTechnologyButton.blocksRaycasts = true;
            buttonImage.color = Color.white;
        }
            
        else
        {
            activeTechnologyButton.blocksRaycasts = false;
            buttonImage.color = specificBlack;
        }
            
            


    }
    
    private bool enoughTechnologyPoint(int value, TechnologyPointTypeSO technologyPointType)
    {
        CivilScienceSO playerScience = CivillizationManager.instance.getPlayerCivilization().GetCivilScience(); 

        if (technologyPointType == redTechnologyPoint)
        {
            if (playerScience.getRedTechnologyPoint() < value)
                return false;
            else
                return true;
        }
        else if (technologyPointType == blueTechnologyPoint)
        {
            if (playerScience.getBlueTechnologyPoint() < value)
                return false;
            else
                return true;
        }
        else
        {
            if (playerScience.getYellowTechnologyPoint() < value)
                return false;
            else
                return true;
        }
    }

    /// <summary>
    /// 获得 currentActiveCost 其中一个的 TechnologyPointType
    /// </summary>
    /// <param name="index">第几个cost</param>
    /// <returns></returns>
    private TechnologyPointTypeSO getAvtiveTechnologyType(int index)
    {
        return currentActiveCost.getTechnologyPointType(index);
 
    }

    /// <summary>
    /// 获得 currentActiveCost 其中一个的 cost
    /// </summary>
    /// <param name="index">第几个cost</param>
    /// <returns></returns>
    private int getAvtiveTechnologyPointCost(int index)
    {
        return currentActiveCost.getTechnologyPointCost(index);
    }

    private void creatspecificBlack()
    {
        specificBlack = new Color(0.353f, 0.353f, 0.353f, 0.706f);
    }

    public void activeTechnology()
    {
        TechnologyManager.TechnologyManagerInstance.setSelectedTecnology(currentTechnologyButton);
        currentTechnologyButton.activeTechnology();
        controlButtonDisplaying();
    }
}
