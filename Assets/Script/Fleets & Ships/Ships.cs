using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{
    private int shipNum = 0;

    private ShipSO shipsType;

    private List<ShipComponentSO> shipComponents = new List<ShipComponentSO>();

    private List<BuffSO> allbuff = new List<BuffSO>();

    public void addShipNum(int num)
    {
        shipNum =+ num;
    }

    public void addBuff(BuffSO buff)
    {
        allbuff.Add(buff);
    }

    public int getShipNum()
    {
        return shipNum;
    }

    public void setShipType(ShipSO ship_type)
    {
        shipsType = ship_type;
    }

    public ShipSO getShipeType()
    {
        return shipsType;
    }

    public void setShipComponents(List<ShipComponentSO> shipComponents)
    {
        this.shipComponents = shipComponents;
    }

    public bool isSameShip(ShipSO shipType, List<ShipComponentSO> components)
    {
        bool sameType = shipsType == shipType;
        bool sameComponents = compareShipComponents(components);

        if (sameType && sameComponents)
            return true;
        else
            return false;
    }


    private bool compareShipComponents(List<ShipComponentSO> components)
    {
        if (components.Count != shipComponents.Count)
            return false;

        bool sameComponents = true;

        for (int i = 0; i < shipComponents.Count; i++)
        {
            if (components[i] == null || shipComponents[i] != components[i])
                sameComponents = false;
        }

        return sameComponents;
    }

    private float getSumOfParameter(GameStatsSO buffType)
    {
        float parameter = 0;

        foreach (BuffSO buff in allbuff)
        {
            parameter += getBuffParameter(buff, buffType);
        }

        return parameter;
    }

    private float getBuffParameter(BuffSO currentBuff, GameStatsSO buffType)
    {
        int index = currentBuff.getGameStatsNum();
        bool existBuffType = false;

        int i;
        for (i = 0; i < index; i++)
        {
            if (currentBuff.getGameStat(i) == buffType)
            {
                existBuffType = true;
                break;
            }
        }

        if (existBuffType)
            return currentBuff.getGameStat_value_float(i);
        else
            return 0;
    }

}
