using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 当点击科技图标时将科学的信息传给 TechnologyDisplay
/// </summary>
public class TechnologyButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private CanvasGroup canvas;

    [SerializeField]private TechnologySO technology;

    [SerializeField]private bool activeState = false;

    private void Start()
    {
        canvas = this.GetComponent<CanvasGroup>();
        technology.setStoreButton(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TechnologyDisplay.DisplayInstance.displayTechnology(this);
    }

    public TechnologySO getTechnology()
    {
        return technology;
    }

    public void show()
    {
        canvas.alpha = 1;
        canvas.blocksRaycasts = true;
    }

    public bool getActiveState()
    {
        return activeState;
    }

    public void activeTechnology()
    {
        activeState = true;
    }

    public void deactiveTechnology()
    {
        activeState = false;
    }
    
}
