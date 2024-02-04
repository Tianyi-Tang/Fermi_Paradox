using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInforElement : DisplayItem
{
    [SerializeField] private RawImage image;
    private Planet viewPlanet;
    [SerializeField] private List<PlanetBuildingSO> planetBuildings;

    private void Start()
    {
        image = this.gameObject.GetComponentInChildren<RawImage>();
    }

    public void SetImageTexture(RenderTexture renderTexture)
    {
        image.texture = renderTexture;
    }

    public void SetViewPlanet(Planet planet)
    {
        viewPlanet = planet;
    }

}
