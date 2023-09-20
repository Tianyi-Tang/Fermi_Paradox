using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 科技树UI
/// </summary>
public class TechnologyTreePanel : BasePanel
{
    private void Start()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void onEnter()
    {
        base.onEnter();
        FindObjectOfType<CameraController>().stopMovingCamera();
    }

    public void OnclosePanel()
    {
        UIManager.Instance.popPanel();
        TechnologyDisplay.DisplayInstance.disactivePanel();
        FindObjectOfType<CameraController>().letCameraMove();
    }

}
