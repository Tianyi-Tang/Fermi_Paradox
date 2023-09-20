using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FleetFactory",menuName = "SO/Factory/FleetFactory")]
public class FleetFactorySO : ScriptableObject
{
    [SerializeField]private Fleet fleet;

    public Fleet creatFleet(Transform destination, List<Ships> ships, float speed,int carryingEnergy,CivilizationSO civilization)
    {
        initializationAttribute(destination, ships, speed, carryingEnergy, civilization);
        return Instantiate(fleet);
    }

    public void initializationAttribute(Transform destination, List<Ships> ships, float speed, int carryingEnergy,CivilizationSO civilization)
    {
        fleet.setDestination(destination);
        fleet.setCarryingEnergy(carryingEnergy);
        fleet.setFleetSpeed(speed);
        fleet.addShips(ships);
        fleet.setCivilization(civilization);
    }
}
