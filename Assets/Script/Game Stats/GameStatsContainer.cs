using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsContainer : MonoBehaviour
{
    public static GameStatsContainer instance;

    [SerializeField] private GameStatsSO Concealment;
    [SerializeField] private GameStatsSO Detection;
    [SerializeField] private GameStatsSO IncreaseMiningSpeed;
    [SerializeField] private GameStatsSO ScienceDevelopmentSpeed;

    [SerializeField] private List<GameStatsSO> civil_baseInfro;

    private void Start()
    {
        instance = this;
    }

    public GameStatsSO getConcealment()
    {
        return Concealment;
    }

    public GameStatsSO getDetection()
    {
        return Detection;
    }

    public GameStatsSO getIncreaseMiningSpeed()
    {
        return IncreaseMiningSpeed;
    }

    public GameStatsSO getScienceDevelopmentSpeed()
    {
        return ScienceDevelopmentSpeed;
    }

    public List<GameStatsSO> getAllGameStatsWithInCivilBasicInfor()
    {
        return civil_baseInfro;
    }
}
