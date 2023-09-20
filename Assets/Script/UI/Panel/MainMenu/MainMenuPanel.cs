using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class MainMenuPanel : BasePanel
{

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
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
    
}
