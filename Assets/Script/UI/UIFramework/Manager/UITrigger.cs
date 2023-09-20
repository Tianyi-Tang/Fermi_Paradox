using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.IO;


/// <summary>
/// 判断点击的物体是否为特殊物体，并显示对应UI
/// </summary>
public class UITrigger : MonoBehaviour
{

    private bool clickFlag = true;
    public event Action<Transform> OnOverView_initialization; //给 Overview panel 的UI 传递被点击行星系的数据

    private UIPanelType currentActiveUI = UIPanelType.Empty;


    private bool selectFlag = false;
    public event Action<Transform> OnSelectPlayerPlanetarySystem; //给 SelectionMainMenu 和 SelectionELement 传递被点击行星系（玩家占领）的数据
    public event Action<Transform> OnSelectPLantarySystem;//给 SelectionMainMenu 和 SelectionELement 传递被点击行星系（非玩家占领）的数据
    [SerializeField]private SelectionElement selection;
    [SerializeField]private SelectionElement player_selection;

    private Transform clickObj;

    [SerializeField]private Vector3 UI_distance; //UI和点击物体的距离


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickFlag && mainMenu())
            {
                clickMode();
            }
            else if (selectFlag)
            {
                selectMode();
            }
        }

    }

    /// <summary>
    /// 判断鼠标点击的物体是否是行星系
    /// </summary>
    /// <returns></returns>
    private bool clickPlanetarySystem()
    {
        if (GameObjectEx.selectObject() == null)
            return false;
        else if (GameObjectEx.selectObject().GetComponent<PlanetarySystem>() != null)
        {
            clickObj = GameObjectEx.selectObject();
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// 判断被点击的行星系是否是属于玩家拥有的星系
    /// </summary>
    /// <returns>是/否</returns>
    private bool ownedPlenetarySystem()
    {
        if (clickObj == null)
            return false;
        else
            return clickObj.GetComponent<PlanetarySystem>().getPlayControl();
    }


    /// <summary>
    /// 判断是否需要弹出UI
    /// </summary>
    private void clickMode()
    {
        planetarySystemUI();
    }
    

    /// <summary>
    /// 根据鼠标点击的物品，判断是否要显示或隐藏 PlanetarySystemOverViewUI 
    /// </summary>
    private void planetarySystemUI()
    {
        if (clickPlanetarySystem())
        {
            closeActiveUI();
            if (ownedPlenetarySystem())
            {
                activatePlayierOverViewUI();
                currentActiveUI = UIPanelType.PlayerOverView;
            }
            else
            {
                activatePlanetarySystemOverViewUI();
                currentActiveUI = UIPanelType.PlanetarySystemOverView;
            }
            Invoke("OverViewUI_initialization", 0.02f);

        }
        else if (clickObj != null)//判断UI是否被激活过
        { 
            if (clickObj.GetComponent<PlanetarySystem>() != null && EventSystem.current.IsPointerOverGameObject() == false)
            {
                closeActiveUI();
            }
        }
    }

    private void closeActiveUI()
    {
        if (currentActiveUI == UIPanelType.PlanetarySystemOverView)
        {
            deactivatePlanetarySystemUI();
        }
        if (currentActiveUI == UIPanelType.PlayerOverView)
        {
            deactivatePlayerOverViewUI();
        }


        currentActiveUI = UIPanelType.Empty;
    }

    /// <summary>
    /// 激活行星系的UI
    /// </summary>
    private void activatePlanetarySystemOverViewUI()
    {
        UIManager.Instance.pushPanel(UIPanelType.PlanetarySystemOverView, clickObj, UI_distance);
        DetectionManager.DetectionInstance.clickPlanetarySystem(clickObj);
    }

    private void deactivatePlanetarySystemUI()
    {
        BasePanel panel = GameObject.FindObjectOfType<PlanetarySystemOverViewPanel>();
        panel.onExit();
    }

    /// <summary>
    /// 激活玩家行星系简介UI
    /// </summary>
    private void activatePlayierOverViewUI()
    {
        UIManager.Instance.pushPanel(UIPanelType.PlayerOverView, clickObj, UI_distance);
    }

    private void deactivatePlayerOverViewUI()
    {
        BasePanel panel = GameObject.FindObjectOfType<PlayerOverViewPanel>();
        panel.onExit();

    }

    /// <summary>
    /// 判断 selectElement 是否需要被弹出
    /// </summary>
    private void selectMode()
    {
        disPatchFleet();
    }

    /// <summary>
    /// 
    /// </summary>
    private void disPatchFleet()
    {
        if (clickPlanetarySystem())
        {
            if (ownedPlenetarySystem())
            {
                activatePlayerSelectionUIElement();
            }
            else
            {

                activateSelectionUIElement();
            }
        }
    }



    private void activatePlayerSelectionUIElement()
    {
        if (player_selection == null)
        {
            player_selection = findSelectionUIElement(true);
        }
        SelectPlayerPlanetarySystem();
        player_selection.OnEnter();
        player_selection.showElement();
    }

    private void activateSelectionUIElement()
    {
        if (selection == null)
        {
            selection = findSelectionUIElement(false);
        }
        SelectPLantarySystem();
        selection.OnEnter();
        selection.showElement();
    }

    private void deactivatePlayerSelectionUIElement()
    {
        player_selection.onExit();
    }

    private void deactivateSelectionUIElement()
    {
        selection.onExit();
    }


    private SelectionElement findSelectionUIElement(bool playerSelectElement)
    {
        SelectionElement[] UIELement = FindObjectsOfType<SelectionElement>();

        if (playerSelectElement == true)
        {
            if (UIELement[0].getPlayerSelect() == true)
                return UIELement[0];
            else
                return UIELement[1];
        }
        else
        {
            if (UIELement[0].getPlayerSelect() == false)
                return UIELement[0];
            else
                return UIELement[1];
        }
    }

    /// <summary>
    /// 让 selection 和 play_selection 暂时消失
    /// </summary>
    public void invisibleSelection()
    {
        if (selection != null || player_selection != null)
        {
            selection.disableElement();
            player_selection.disableElement();
        }

    }


    /// <summary>
    /// 接收从 PlantarySystemMainMenu 传输的数据，并激活 playerSelectionUI
    /// </summary>
    /// <param name="playerPlanetarySystem">当前被选中的行星系</param>
    public void initiaPlayerPlanetarySystem(Transform playerPlanetarySystem)
    {
        clickObj = playerPlanetarySystem;
        activatePlayerSelectionUIElement();
    }
    

    /// <summary>
    /// 将被点击的行星系传给UI，让其初始化
    /// </summary>
    private void OverViewUI_initialization()
    {
        if (OnOverView_initialization != null)
        {
            OnOverView_initialization(clickObj);
        }
    }

    private void SelectPlayerPlanetarySystem()
    {
        if (OnSelectPlayerPlanetarySystem != null)
        {
            OnSelectPlayerPlanetarySystem(clickObj);
        }
    }

    private void SelectPLantarySystem()
    {
        if (OnSelectPLantarySystem != null)
        {
            OnSelectPLantarySystem(clickObj);
        }
    }

    /// <summary>
    /// 如果现在显示的UI为 MainMenuPanel 的话就返回 true，否则返回 false
    /// </summary>
    /// <returns>是否为 MainMenuPanel</returns>
    private bool mainMenu()
    {
        if (UIManager.Instance.getTopUI().GetComponent<MainMenuPanel>() != null)
            return true;
        else
            return false;
    }

    public Vector3 getVector3()
    {
        return UI_distance;
    }

    public void turnOffClickMode()
    {
        clickFlag = false;
    }

    public void turnOnClickMode()
    {
        clickFlag = true;
    }

    public void turnOffSelectMode()
    {
        selectFlag = false;
        if(player_selection != null)
            deactivatePlayerSelectionUIElement();
        if(selection != null)
        deactivateSelectionUIElement();
    }

    public void turnOnSelectMode()
    {
        selectFlag = true;
    }

}
