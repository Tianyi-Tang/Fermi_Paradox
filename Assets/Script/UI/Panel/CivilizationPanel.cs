using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilizationPanel : BasePanel
{

    private void Start()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnclosePanel()
    {
        UIManager.Instance.popPanel();
    }
}
