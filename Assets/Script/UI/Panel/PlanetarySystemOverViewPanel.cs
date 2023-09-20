using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 显示行星系（玩家未占领）的行星
/// </summary>
public class PlanetarySystemOverViewPanel : OverViewPanel
{
    [SerializeField]private Text planetNum;
    private DetectionErrorSO detectionError;

    protected override void Start()
    {
        base.Start();
        trigger.OnOverView_initialization += initializationUI;

        FindObjectOfType<DetectionManager>().OnSendingDetectionError += setDetectionError;

        UIRoot.UIRootInstance.completeInitalization(this);
    }

    /// <summary>
    /// 初始化UI，显示被点击行星系的信息
    /// </summary>
    /// <param name="obj">行星系</param>
    private void initializationUI(Transform obj)
    {
        currentPlanteraySystem = obj;
        if(activeUI == true)
            planetNum.text = planetNumStandardization().ToString();
    }

    private void setDetectionError(DetectionErrorSO detectionError)
    {
        this.detectionError = detectionError;
    }

    private int planetNumStandardization()
    {
        int planetNum = currentPlanteraySystem.GetComponent<PlanetarySystem>().getPlanetsNum();
        if (detectionError.getPlanetsNum() > planetNum)
            planetNum = 0;
        else
            planetNum -= detectionError.getPlanetsNum();

        return planetNum;
    }


}
