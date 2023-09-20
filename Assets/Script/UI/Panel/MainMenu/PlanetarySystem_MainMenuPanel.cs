using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 进入玩家星球后的UI主界面
/// </summary>
public class PlanetarySystem_MainMenuPanel : BasePanel
{
    private PlanetarySystem currentPlanetarySystem;
   
    private event Action OnCameraRelease;

    public event Action<Transform> OnPlayerPlanetarySystem;//当从该UI跳转到 SelectionMainMenu 时，将 currentPlanetarySystem 传递给 Selection_MainMenuPanel 和  UITrigger，来达到在第一时显示 SelectionELement
    public event Action<PlanetarySystem> OnSendPlanetarySystem;//向所有依附于 lanetarySystem_MainMenuPanel 的 UIPanel 传递数据

    private void Start()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        CameraController camera = GameObject.FindObjectOfType<CameraController>();
        OnCameraRelease += camera.backInitialState;

        UITrigger trigger = GameObject.FindObjectOfType<UITrigger>();
        OnPlayerPlanetarySystem += trigger.initiaPlayerPlanetarySystem;

        GameObject.FindObjectOfType<PlayerOverViewPanel>().OnPlantarySystemUI_initialization += setCurrentPlanetarySystem;

        UIRoot.UIRootInstance.completeInitalization(this);
    }

    public override void onPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public override void onResume()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIManager.Instance.pushPanel(panelType);
    }

    public void setCurrentPlanetarySystem(PlanetarySystem planetarySystem) 
    {
        currentPlanetarySystem = planetarySystem;
    }

    public void PlanetViewPanel()
    {
        OnSendPlanetarySystem(currentPlanetarySystem);
        UIManager.Instance.pushPanel(UIPanelType.PlanetsView);
    }
   
    public void exitPlanetarySystem_MainMenu()
    {
        UIManager.Instance.switchMainMenu(UIPanelType.MainMenu);
        OnCameraRelease();
        currentPlanetarySystem.starsInvisible();
        FindObjectOfType<PlanetsViewPanel>().clearAllView();
    }

    public void selectPlanetarySystem(bool launchProjectile)
    {
        UIManager.Instance.switchMainMenu(UIPanelType.Selection_MainMenu);
        OnCameraRelease();
        if(launchProjectile)
            switchSeletionMode();
        currentPlanetarySystem.starsInvisible();
        PlayerPlanetarySystem();
    }

    private void switchSeletionMode()
    {
        Selection_MainMenuPanel mainMenuPanel = FindObjectOfType<Selection_MainMenuPanel>();
        mainMenuPanel.projectileMode = true;
    }

    private void PlayerPlanetarySystem()
    {
        OnPlayerPlanetarySystem(currentPlanetarySystem.transform);
    }
}
