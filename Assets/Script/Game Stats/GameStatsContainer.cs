using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsContainer : MonoBehaviour
{
    public static GameStatsContainer instance;

    [SerializeField] private GameParameterSO Concealment;
    [SerializeField] private GameParameterSO Detection;
    [SerializeField] private GameParameterSO IncreaseMiningSpeed;
    [SerializeField] private GameParameterSO ScienceDevelopmentSpeed;

    [SerializeField] private List<GameParameterSO> civil_baseInfro;

    private void Start()
    {
        instance = this;
    }

    public GameParameterSO getConcealment()
    {
        return Concealment;
    }

    public GameParameterSO getDetection()
    {
        return Detection;
    }

    public GameParameterSO getIncreaseMiningSpeed()
    {
        return IncreaseMiningSpeed;
    }

    public GameParameterSO getScienceDevelopmentSpeed()
    {
        return ScienceDevelopmentSpeed;
    }

    public List<GameParameterSO> getAllGameStatsWithInCivilBasicInfor()
    {
        return civil_baseInfro;
    }
}
