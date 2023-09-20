using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有飞船的父类
/// </summary>
public class ShipSO : ScriptableObject
{
    [SerializeField]protected float shipSpeed;
    [SerializeField]protected int shipCrypticity;
    [SerializeField]protected int shipEnergyConsumption;
    [SerializeField]protected float shipSize;

    public float getShipSpeed()
    {
        return shipSpeed;
    }

    public int getShipCrypticity()
    {
        return shipCrypticity;
    }

    public float getShipSize()
    {
        return shipSize;
    }
}
