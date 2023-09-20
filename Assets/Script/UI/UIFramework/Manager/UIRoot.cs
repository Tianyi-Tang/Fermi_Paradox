using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 将所有需要通过 event 传输数据的 UI 初始化，并在完成后加载 MainMenu 
/// </summary>
public class UIRoot : MonoBehaviour
{
    public static UIRoot UIRootInstance;

    // Start is called before the first frame update
    void Start()
    {
        UIRootInstance = this;
        StartCoroutine(initialUIEvent());
        StartCoroutine(initialDepentUIEvent());
    }

    IEnumerator initialUIEvent()
    {
        UIManager.Instance.pushPanel(UIPanelType.PlanetarySystemOverView);
        UIManager.Instance.pushPanel(UIPanelType.PlayerOverView);
        UIManager.Instance.pushPanel(UIPanelType.PlanetarySystem_MainMenu);

        UIManager.Instance.getUIElement("UI/UIElement/PlayerSelectionUIElement");
        UIManager.Instance.getUIElement("UI/UIElement/SelectionUIElement");

        yield return new WaitForSeconds(0.02f);
    }

    IEnumerator initialDepentUIEvent()
    {
        UIManager.Instance.pushPanel(UIPanelType.Selection_MainMenu);
        UIManager.Instance.pushPanel(UIPanelType.PlanetsView);


        yield return new WaitForSeconds(0.02f);

        UIManager.Instance.pushPanel(UIPanelType.MainMenu);
    }

    
    public void completeInitalization(BasePanel panel)
    {
        panel.onExit();
        UIManager.Instance.popPanel();
    }

    public void completeInitalization(SelectionElement element)
    {
        element.onExit();
    }
   
}
