using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 创建Ships的class
/// </summary>
public class CreateShips : MonoBehaviour
{
    public static CreateShips instance;
    
    void Start()
    {
        instance = this;
    }

    public Ships generateShips(List<ShipComponentSO> shipComponents, ShipSO shipType,int number,GameObject shipsContainer)
    {
        sortShipComponenets(shipComponents, 0, shipComponents.Count);
        Ships[] ownerShips = shipsContainer.GetComponents<Ships>();

        foreach (Ships ships in ownerShips)
        {
            if (ships.isSameShip(shipType, shipComponents))
            {
                ships.addShipNum(number);
                return null;
            }
        }
        return creatNewShips(shipComponents, shipType, number, shipsContainer);
    }

    public Ships creatNewShips(List<ShipComponentSO> shipComponents, ShipSO shipType, int number, GameObject shipsContainer)
    {
        Ships ships = shipsContainer.AddComponent<Ships>();
        ships.setShipComponents(shipComponents);
        ships.setShipType(shipType);
        ships.addShipNum(number);
        return ships;
    }


    private void sortShipComponenets(List<ShipComponentSO> shipComponents,int start,int end)
    {
        if (start >= end)
            return;

        int povit = shipComponents[end].getComponetOrder();
        int i = 0;

        for (int j = start; j < end; j++)
        {
            if (shipComponents[j].getComponetOrder() <= povit)
            {
                swap(i, j, shipComponents);
                i++;
            }     
        }
        swap(i, end,shipComponents);

        sortShipComponenets(shipComponents, start, i - 1);
        sortShipComponenets(shipComponents, i + 1, end);

    }

    private void swap(int index1, int index2,List<ShipComponentSO> shipComponents)
    {
        ShipComponentSO temp = shipComponents[index1];
        shipComponents[index1] = shipComponents[index2];
        shipComponents[index2] = temp;
    }
}
