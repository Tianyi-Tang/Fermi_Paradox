using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 初始化舰队
/// </summary>
public class FleetManager : MonoBehaviour
{
    //private event Action<Vector3, List<TechnologyPointSO>> OnSendMessage;

    [SerializeField]private FleetFactorySO fleetFactorySO;

    public static FleetManager FleetInstance;

    private void Start()
    {
        FleetInstance = this;
    }


    /// <summary>
    /// 创造舰队
    /// </summary>
    /// <param name="departure">舰队的出发点</param>
    /// <param name="destination">舰队的终点</param>
    /// <param name="ships">舰队包含的飞船</param>
    public void createFleet(Transform departure, Transform destination, List<Ships> ships)
    {
        float minimumSpeed = getMinimum(getShipSpeed, ships);//舰队的整体速度为舰队中最慢的飞船决定
        int carryingEnergy = getTotal(getShipCrypticity, ships);
        Fleet fleet = fleetFactorySO.creatFleet(destination, ships, minimumSpeed, carryingEnergy,departure.GetComponent<Colony>().getPlanetarySystemOwner());
        fleet.transform.position = departure.position;
    }


    private float getShipSpeed(Ships ships)
    {
        return ships.getShipeType().getShipSpeed();
    }

    private int getShipCrypticity(Ships ships)
    {
        return ships.getShipeType().getShipCrypticity();
    }

    /// <summary>
    /// 查找最小 float 的模版方法
    /// </summary>
    /// <param name="_func">参数为 ShipSO 输出为 float 的方法</param>
    /// <param name="ships">舰队中的所有飞船</param>
    /// <returns></returns>
    private float getMinimum(Func<Ships,float> _func, List<Ships> ships)
    {
        float minimumRecord = _func(ships[0]);

        foreach (Ships ship in ships)
        {
            float tempNum = _func(ship);

            if (tempNum < minimumRecord)
                minimumRecord = tempNum;
        }
        return minimumRecord;
    }

    private float getMaximum(Func<Ships, float> _func, List<Ships> ships)
    {

        float maximumRecord = _func(ships[0]);

        foreach (Ships ship in ships)
        {
            float tempNum = _func(ship);

            if (tempNum > maximumRecord)
                maximumRecord = tempNum;
        }
        return maximumRecord;
    }

    private int getTotal(Func<Ships, int> _func, List<Ships> ships)
    {
        int total = 0;
        foreach (Ships ship in ships)
            total += _func(ship);
        return total;
    }



}
