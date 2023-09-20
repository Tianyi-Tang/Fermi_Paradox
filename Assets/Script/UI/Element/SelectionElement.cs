using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 标记选择物体的UI
/// </summary>
public class SelectionElement : MonoBehaviour
{
    private Transform seletElement;

    [SerializeField] private bool playerSelect = false;
    private CanvasGroup canvasGroup;

    private bool activeElement = false;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        UITrigger trigger = FindObjectOfType<UITrigger>();
        if (playerSelect == false)
        {
            trigger.OnSelectPLantarySystem += setSeletElement;
        }
        else
        {
            trigger.OnSelectPlayerPlanetarySystem += setSeletElement;
        }
            

        UIRoot.UIRootInstance.completeInitalization(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeElement)
        {
            transform.position = Camera.main.WorldToScreenPoint(seletElement.position);
        }
    }

    public void onExit()
    {
        canvasGroup.alpha = 0;
        activeElement = false;
    }

    public void OnEnter()
    {
        activeElement = true;
    }

    public void showElement()
    {
        if(activeElement == true && canvasGroup.alpha != 1)
            canvasGroup.alpha = 1;
    }

    public void disableElement()
    {
        canvasGroup.alpha = 0;
    }


    public void setSeletElement(Transform planetarySystem)
    {
        seletElement = planetarySystem;
        
    }


    public bool getPlayerSelect()
    {
        return playerSelect;
    }

    
}