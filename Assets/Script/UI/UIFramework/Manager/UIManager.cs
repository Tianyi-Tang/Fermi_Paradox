using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 管理所有UI的显示和关闭
/// </summary>
public class UIManager
{
    private static UIManager _instance; //单例化

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.FindObjectOfType<UIRoot>().transform;
            }
            return canvasTransform;
        }   
    }

    private UITrigger trigger;
    private UITrigger Trigger
    {
        get
        {
            if (trigger == null)
            {
                trigger = GameObject.FindObjectOfType<UITrigger>();
            }
            return trigger;
        }
    }

    private Dictionary<UIPanelType, string> panelPathDict; //存储所有面板prefab的路径
    private Dictionary<UIPanelType, BasePanel> panelDict; //保存所有实例化的面板
    private Stack<BasePanel> panelStack;

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }


    private UIManager()
    {
        parseUIPanelTypeJson();
    }

    /// <summary>
    /// 将指定的页面入栈，并显示在界面上
    /// </summary>
    /// <param name="panelType"></param>
    public void pushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        //判断栈里面是否有页面
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.onPause();
        }
        BasePanel panel = GetPanel(panelType);
        panel.onEnter();
        panelStack.Push(panel);

    }

    /// <summary>
    /// 当特定物体被点进时，根据物体位置弹出UI
    /// </summary>
    /// <param name="panelType">UI的名字</param>
    /// <param name="objTransform">特定物体的位置</param>
    /// <param name="UI_distance">要调整</param>
    public void pushPanel(UIPanelType panelType, Transform objTransform,Vector3 UI_distance)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(objTransform.position);
        UI_distance.Set(screenPoint.x + UI_distance.x, screenPoint.y + UI_distance.y, 0);

        BasePanel panel = GetPanel(panelType);
        panel.transform.position = UI_distance;
        panel.onEnter();
    }

    /// <summary>
    /// 出栈，并把页面在界面上移除，并显示下面的页面
    /// </summary>
    public void popPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;

        //关闭栈顶页面的显示
        BasePanel topPanel = panelStack.Pop();
        
        topPanel.onExit();

        if (panelStack.Count <= 0) return;

        BasePanel nextPanel = panelStack.Peek();
        nextPanel.onResume();
    }

    
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            //如果找不到，就去找该面板prefab的路径，并实例化面板
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }
    }
    

    private void parseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
        }
    }

    public void getUIElement(String path)
    {
        GameObject insElement = GameObject.Instantiate(Resources.Load(path) as GameObject);
        insElement.transform.SetParent(canvasTransform, false);
    }

    private bool mainMean()
    {
        if (panelStack.Peek().GetComponent<MainMenuPanel>() != null)
            return true;
        else
            return false;
    }

    public BasePanel getTopUI()
    {
        return panelStack.Peek();
    }

    
    public void switchMainMenu(UIPanelType panelType)
    {

        if (panelStack.Count != 1)
            return;

        if (panelStack.Peek().GetComponent<MainMenuPanel>() != null && panelType == UIPanelType.PlanetarySystem_MainMenu)
            Trigger.turnOffClickMode();
        else if (panelStack.Peek().GetComponent<PlanetarySystem_MainMenuPanel>() != null && panelType == UIPanelType.MainMenu)
            Trigger.turnOnClickMode();
        else if (panelStack.Peek().GetComponent<PlanetarySystem_MainMenuPanel>() != null && panelType == UIPanelType.Selection_MainMenu)
            Trigger.turnOnSelectMode();
        else if (panelStack.Peek().GetComponent<MainMenuPanel>() != null && panelType == UIPanelType.Selection_MainMenu)
        {
            Trigger.turnOffClickMode();
            Trigger.turnOnSelectMode();
        }
        else if (panelStack.Peek().GetComponent<Selection_MainMenuPanel>() != null && panelType == UIPanelType.PlanetarySystem_MainMenu)
            Trigger.turnOffSelectMode();
        else if (panelStack.Peek().GetComponent<Selection_MainMenuPanel>() != null && panelType == UIPanelType.MainMenu)
        {
            Trigger.turnOffSelectMode();
            Trigger.turnOnClickMode();
        }

        popPanel();

        pushPanel(panelType);

    }
    

    

}
