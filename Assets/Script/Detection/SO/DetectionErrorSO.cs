using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DetectionError", menuName = "SO/Detection/DetectionError")]
public class DetectionErrorSO : ScriptableObject
{
    [SerializeField]private int planetsNum;

    public void setPlanetsNum(int newPlanetsNum)
    {
        planetsNum = newPlanetsNum;
    }

    public int getPlanetsNum()
    {
        return planetsNum;
    }
}
