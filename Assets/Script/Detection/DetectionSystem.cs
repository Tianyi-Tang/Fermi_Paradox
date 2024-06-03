using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    private List<PlanetarySystem> monitoring_planetarySystems = new List<PlanetarySystem>(); //被持续观测的行星系
    private List<StarsSegmentae> monitoring_Segmentae = new List<StarsSegmentae>(); //被观察的星域

    [SerializeField]private List<PlanetarySystem> observationArea_planetarySystems = new List<PlanetarySystem>();//在行星系探测范围内的星系


    private float concealmentParameter;

    [SerializeField]private CivilizationSO civilzation;

    private void Start()
    {
        DetectionManager.DetectionInstance.OnSendingConcealmentParameter += setConcealmentParameter;

        detectNearbyPlanetarySystem();
    }

    public void setCivilzation(CivilizationSO civilzation)
    {
        if(!this.enabled)
        {
            this.enabled = true;
        }
        this.civilzation = civilzation;
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.transform.GetComponent<PlanetarySystem>() != null)
        {
            observationArea_planetarySystems.Add(collision.transform.GetComponent<PlanetarySystem>());
        }
    }

    /// <summary>
    /// 当文明占领一个新行星系时或探测范围改变时调用，用来观测在探测范围内的行星系
    /// </summary>
    private void detectNearbyPlanetarySystem()
    {
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, 30);

        foreach (Collider collider in hitCollider)
        {
            PlanetarySystem nearbyPlanetarySystem = collider.GetComponent<PlanetarySystem>();
            if (nearbyPlanetarySystem != null && alreadyExist(nearbyPlanetarySystem) == false)
            {
                addIntoObservationArea(nearbyPlanetarySystem);
            }
        }
    }

    private void addIntoObservationArea(PlanetarySystem nearbyPlanetarySystem)
    {
        observationArea_planetarySystems.Add(nearbyPlanetarySystem);
    }

    /// <summary>
    /// 查看被给予的行星系是否已经被持续观测了
    /// </summary>
    /// <param name="planetarySystem">被给予的行星系</param>
    /// <returns>如果已经被持续观测或者出现异常情况，返回 true；如果否，则返回 false</returns>
    private bool alreadyExist(PlanetarySystem planetarySystem)
    {
        if (planetarySystem == null)
            return true;
        else if (planetarySystem == transform.GetComponent<PlanetarySystem>())
            return true;
        else
        {

            foreach (PlanetarySystem planetary in observationArea_planetarySystems)
            {
                if (planetarySystem == planetary)
                    return true;
            }
            return false;
        }

    }

    private void setConcealmentParameter(float concealmentParameter)
    {
        this.concealmentParameter = concealmentParameter;
    }

    public float getDectionParamter()
    {
        return civilzation.getGameStats_flaot(GameParameterContainer.instance.getDetection());
    }

    /// <summary>
    /// 查看给予的行星系是否已经被持续性的观测了
    /// </summary>
    /// <param name="planetary">给予的行星系</param>
    /// <returns>如果已经被持续的观测，返回 true；如果否，则返回 false</returns>
    public bool searchPlanetarySystem(PlanetarySystem planetary)
    {
        for (int i = 0; i < monitoring_planetarySystems.Count; i++)
        {
            if (monitoring_planetarySystems[i] == planetary)
                return true;
        }

        for (int j = 0; j < observationArea_planetarySystems.Count; j++)
        {
            if (observationArea_planetarySystems[j] == planetary)
                return true;
        }

        return false;
    }

    /// <summary>
    /// 查看给予的星域是否已经被持续性的观测了
    /// </summary>
    /// <param name="segmentae">给予的星域</param>
    /// <returns>如果已经被持续的观测，返回 true；如果否，则返回 false</returns>
    public bool searchSegmentae(StarsSegmentae segmentae)
    {
        for (int i = 0; i < monitoring_Segmentae.Count; i++)
        {
            if (monitoring_Segmentae[i] == segmentae)
                return true;
        }
        return false;
    }

}
