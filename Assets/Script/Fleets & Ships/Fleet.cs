using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制舰队运行和能量消耗的脚本
/// </summary>
public class Fleet : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField]private Vector3 destinationPosition;

    [SerializeField] private CivilizationSO civilization;
    [SerializeField]private List<Ships> ships;

    [SerializeField] private bool move_flag = true;
    [SerializeField] private float fleetSpeed;

    [SerializeField]private int carryingEnergy;
    [SerializeField]private int movingConsumption;
    [SerializeField]private int stopConsumption;

    private void Update()
    {
        if (move_flag == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPosition, fleetSpeed * Time.deltaTime);
            reachDestination();
        }
    }
   

    public void setDestination(Transform destination)
    {
        this.destination = destination;
        destinationPosition = destination.position;
    }

    public void setCivilization(CivilizationSO civilization)
    {
        this.civilization = civilization;
    }

    public void setFleetSpeed(float fleetSpeed)
    {
        this.fleetSpeed = fleetSpeed;
    }

    public void addShips(List<Ships> ships)
    {
        this.ships = ships;
    }

    public void setCarryingEnergy(int carryingEnergy)
    {
        this.carryingEnergy = carryingEnergy;
    }

    public void moveFleet()
    {
        move_flag = true;
    }

    public void stopFleet()
    {
        move_flag = false;
    }

    private void reachDestination()
    {
        if (transform.position == destinationPosition)
        {
            move_flag = false;
            destination.GetComponent<PlanetarySystem>().occupy(civilization);
            Destroy(gameObject);
        }
            
    }



}
