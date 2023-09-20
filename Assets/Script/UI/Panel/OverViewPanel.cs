using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有 OverViewPanel 的父类，仅供继承
/// </summary>
public class OverViewPanel : BasePanel
{
    [SerializeField]protected Transform currentPlanteraySystem;

    protected UITrigger trigger;
    protected Vector3 distance;
    [SerializeField]protected bool activeUI = false;

    public override void onEnter()
    {
        base.onEnter();
        canvasGroup.alpha = 1;
        activeUI = true;
    }

    public override void onExit()
    {
        base.onExit();
        activeUI = false;
        canvasGroup.alpha = 0;
    }

    protected virtual void Start()
    {
        trigger = GameObject.FindObjectOfType<UITrigger>();
        distance = trigger.getVector3();

        canvasGroup = GetComponent<CanvasGroup>();
    }

    protected virtual void Update()
    {
        if (activeUI && currentPlanteraySystem != null)//当UI显示时
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(currentPlanteraySystem.position);
            transform.position = new Vector3(distance.x + screenPosition.x, distance.y + screenPosition.y);
        }
    }

    protected void showUI()
    {
        if (existCurrentPlanteraySystem()&& activeUI == true && canvasGroup.alpha ==0)
            canvasGroup.alpha = 1;
    }

    protected bool existCurrentPlanteraySystem()
    {
        if (currentPlanteraySystem == null)
            return false;
        else
            return true;
    }

}
