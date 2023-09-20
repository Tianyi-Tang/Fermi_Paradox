using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 选择物体时的主UI
/// </summary>
public class Selection_MainMenuPanel : BasePanel
{

    private UIPanelType exitUI = UIPanelType.PlanetarySystem_MainMenu;

    private Transform startPlantarySystem;

    private Transform startingPoint;
    private Transform terminalPoint;

    public bool projectileMode = false;

    [SerializeField] private CanvasGroup fleet_button;
    [SerializeField] private CanvasGroup projectile_button;

    private UITrigger trigger;

    private event Action<Transform> OnCameraFocusing;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        trigger = FindObjectOfType<UITrigger>();
        trigger.OnSelectPlayerPlanetarySystem += setStartingPoint;
        trigger.OnSelectPLantarySystem += setTerminalPoint;

        PlanetarySystem_MainMenuPanel mainMenuPL = FindObjectOfType<PlanetarySystem_MainMenuPanel>();
        mainMenuPL.OnPlayerPlanetarySystem += noteInitialPosition;

        FindObjectOfType<PlayerOverViewPanel>().OnSelection += noteInitialPosition;

        CameraController camera = FindObjectOfType<CameraController>();
        OnCameraFocusing += camera.focusingPlanetarySystem;

        
        if (projectileMode)
        {
            fleet_button.alpha = 0;
            fleet_button.blocksRaycasts = false;
        }
        else
        {
            //projectile_button.alpha = 0;
            //projectile_button.blocksRaycasts = false;
        }

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

    private void noteInitialPosition(Transform transform)
    {
        startPlantarySystem = transform;
        startingPoint = transform;
    }

    private void noteInitialPosition(Transform transform, UIPanelType panelType)
    {
        startingPoint = transform;
        exitUI = panelType;
    }

    public void launchFleet()
    {
        if (startingPoint != null && terminalPoint != null)
        {
            FleetManager.FleetInstance.createFleet(startingPoint, terminalPoint, startingPoint.GetComponent<PlanetarySystem>().getFleets());
            trigger.invisibleSelection();
        }
            
        else
            Debug.Log("miss the information");
    }

    public void exitSelection_MainMenuPanel()
    {
        UIManager.Instance.switchMainMenu(exitUI);
        if (exitUI == UIPanelType.PlanetarySystem_MainMenu)
        {
            OnCameraFocusing(startPlantarySystem);
            startPlantarySystem.GetComponent<PlanetarySystem>().starsVisible();
        }

        startingPoint = null;
        terminalPoint = null;
        exitUI = UIPanelType.PlanetarySystem_MainMenu;
    }

    private void setStartingPoint(Transform owned)
    {
        startingPoint = owned;
    }

    private void setTerminalPoint(Transform other)
    {
        terminalPoint = other;
    }
}
