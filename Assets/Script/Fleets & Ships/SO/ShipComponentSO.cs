using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipComponent", menuName ="SO/Ships/ShipComonent")]
public class ShipComponentSO : ScriptableObject
{
    private static int counterNumber = 1;

    [ReadyOnly]
    [SerializeField] private int componentOrder;

    [SerializeField] private string componentName;
    [SerializeField] private string description;

    [SerializeField] private BuffSO carryBuff;
    [SerializeField] private float cost;

    private void Awake()
    {
        componentOrder = counterNumber++;
    }

    public BuffSO getBuff()
    {
        return carryBuff;
    }

    public float getCost()
    {
        return cost;
    }

    public int getComponetOrder()
    {
        return componentOrder;
    }
}
