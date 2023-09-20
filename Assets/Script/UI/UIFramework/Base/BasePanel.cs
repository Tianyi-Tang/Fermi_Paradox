using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有panel的父类
/// </summary>
public class BasePanel : MonoBehaviour
{
    protected CanvasGroup canvasGroup;

    /// <summary>
    /// 显示界面
    /// </summary>
    public virtual void onEnter()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void onPause()
    {

    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void onResume()
    {

    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public virtual void onExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
