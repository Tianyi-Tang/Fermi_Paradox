using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsViewPanel : BasePanel
{

    [SerializeField] private List<RenderTexture> planetViewTextures;
    [SerializeField] private List<PlanetViewCamera> planetViewCameras = new List<PlanetViewCamera>();

    private LoopListView viewMaker;
    private List<PlanetInforElement> planetInforElements = new List<PlanetInforElement>();

    private List<Planet> currentPlanets;
    private PlanetarySystem planetarySystem;

    

    void Start()
    {

        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        FindObjectOfType<PlanetarySystem_MainMenuPanel>().OnSendPlanetarySystem += setCurrentSystem;
        viewMaker = this.GetComponent<LoopListView>();

        UIRoot.UIRootInstance.completeInitalization(this);
    }

    public override void onEnter()
    {
        base.onEnter();
        initializPanel();
    }

    private void setCurrentSystem(PlanetarySystem currentSystem)
    {
        currentPlanets = currentSystem.GetPlanets();
        planetarySystem = currentSystem;
    }

    /// <summary>
    /// 初始化 Panel 的 外观
    /// </summary>
    private void initializPanel()
    {
       
        if (currentPlanets == null)
            return;
        for (int i = 0; i < currentPlanets.Count; i++)
        {
            addCameraToPlanet(currentPlanets[i], instancePlanetViewCamera(), planetViewTextures[i]);
            PlanetInforElement item = (PlanetInforElement)viewMaker.addNewItem();

            item.SetImageTexture(planetViewTextures[i]);
            item.SetViewPlanet(currentPlanets[i]);
            planetInforElements.Add(item);
        }

    }

    private void addCameraToPlanet(Planet planet, GameObject camera, RenderTexture renderTexture)
    {
        camera.GetComponent<PlanetViewCamera>().setPlanet(planet);
        camera.GetComponent<Camera>().targetTexture = renderTexture;
        planetViewCameras.Add(camera.GetComponent<PlanetViewCamera>());
    }

    private GameObject instancePlanetViewCamera()
    {
        return Instantiate(Resources.Load<GameObject>("Camera/PlantViewCamera"));
    }

    public void OnclosePanel()
    {
        UIManager.Instance.popPanel();
    }

    public void clearAllView()
    {
        viewMaker.turnToOrginal();

        if (planetViewCameras[0] == null)
            return;

        Destroy(planetViewCameras[0].gameObject);
        for (int i = 1; i < currentPlanets.Count; i++)
        {
            Destroy(planetInforElements[i].gameObject);
            Destroy(planetViewCameras[i].gameObject);
        }

    }

    public void addColonyToPlanet(Planet planet, PlanetBuildingSO planetBuilding)
    {
        planetarySystem.SetColony(planet,planetBuilding);
    }


}
