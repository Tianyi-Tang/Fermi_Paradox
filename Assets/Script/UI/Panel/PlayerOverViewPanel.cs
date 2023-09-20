using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 显示行星系（玩家拥有）的信息，并提供进入该行星系的功能
/// </summary>
public class PlayerOverViewPanel : OverViewPanel
{
    private event Action<Transform> OnCameraFocusing;
    public event Action<PlanetarySystem> OnPlantarySystemUI_initialization;//当从 MainMenu 跳转 PlanetarySystemMainMenu 时，将显示行星系的数据 传递给 PlanetarySystemMainMenu
    public event Action<Transform, UIPanelType> OnSelection;//当从该UI跳转到 SelectionMainMenu 时,将 退出时的 UIPanelType 和选择的行星系 传递给 SelectionMainMenu
    private event Action<Transform> OnPlayerPlanetarySystem; //当从该UI跳转到 SelectionMainMenu 时，将 currentPlanetarySystem 传递给 Selection_MainMenuPanel 和  UITrigger，来达到在第一时显示 SelectionELement

    protected override void Start()
    {
        base.Start();
        trigger.OnOverView_initialization += initializationUI;

        OnPlayerPlanetarySystem += FindObjectOfType<UITrigger>().initiaPlayerPlanetarySystem;

        CameraController controller = GameObject.FindObjectOfType<CameraController>();
        OnCameraFocusing += controller.focusingPlanetarySystem;

        UIRoot.UIRootInstance.completeInitalization(this);
    }

    protected override void Update()
    {
        base.Update();
    }


    private void initializationUI(Transform obj)
    {
        currentPlanteraySystem = obj;
    }

    /// <summary>
    /// 当 Planetary 按钮被点击后
    /// </summary>
    public void OnClickPlanetaryButton()
    {
        onExit();
        CameraFocusing();

        UIManager.Instance.switchMainMenu(UIPanelType.PlanetarySystem_MainMenu);
    }

    public void onClickSelectButton()
    {
        onExit();
        OnSelection(currentPlanteraySystem.transform, UIPanelType.MainMenu);
        OnPlayerPlanetarySystem(currentPlanteraySystem.transform);
        UIManager.Instance.switchMainMenu(UIPanelType.Selection_MainMenu);
    }

    /// <summary>
    /// 将摄像头聚焦到被点击到行星系
    /// </summary>
    private void CameraFocusing()
    {
        if (currentPlanteraySystem != null)
        {
            PlanetarySystem planetarySystem = currentPlanteraySystem.GetComponent<PlanetarySystem>();
            planetarySystem.starsVisible();

            OnCameraFocusing(currentPlanteraySystem);
            Invoke("PlantarySystemUI_initialization", 0.01f);
        }
    }

    private void PlantarySystemUI_initialization()
    {
        if (OnPlantarySystemUI_initialization != null)
            OnPlantarySystemUI_initialization(currentPlanteraySystem.GetComponent<PlanetarySystem>());
    }
}
