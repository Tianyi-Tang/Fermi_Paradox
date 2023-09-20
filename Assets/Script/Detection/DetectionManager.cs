using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 判断文明是否能探测到信息和决定文明观察信息的误差
/// </summary>
public class DetectionManager : MonoBehaviour
{
    private List<DetectionSystem> player_detectionSystem;

    [SerializeField]private DetectionErrorSO detectionError;

    public event Action<float> OnSendingConcealmentParameter;

    public event Action<DetectionErrorSO> OnSendingDetectionError;

    public static DetectionManager DetectionInstance;

    private void Awake()
    {
        player_detectionSystem = new List<DetectionSystem>();
        DetectionInstance = this;
    }

    public void addPlayer_detectionSystem(DetectionSystem detectionSystem)
    {
        player_detectionSystem.Add(detectionSystem);
    }

    /// <summary>
    /// 被 UITrigger 所调用，来计算 dectionerror
    /// </summary>
    /// <param name="target"></param>
    public void clickPlanetarySystem(Transform target)
    {
        generateDectionError(calcualteMax_playerDectionParameter(target));
    }

    /// <summary>
    /// 找到文明拥有星系中侦查值最高的一个行星系，并用这个最高的值计算对被观测行星系的误差
    /// </summary>
    /// <param name="target">被观测的行星系</param>
    /// <returns>误差值</returns>
    private float calcualteMax_playerDectionParameter(Transform target)
    {
        float max_dectionParameter= -99;
        float currentdectionParameter;

        int index = 0;


        do
        {
            currentdectionParameter = player_detectionSystem[index].getDectionParamter() + addtionalDectionParameter(player_detectionSystem[index],target);
            currentdectionParameter -= calculateDistanceAffect(target, player_detectionSystem[index].transform);

            if (max_dectionParameter < currentdectionParameter)
                max_dectionParameter = currentdectionParameter;
            index++;
        } while (index+1 < player_detectionSystem.Count);

        return max_dectionParameter;
    }

    private float addtionalDectionParameter(DetectionSystem civilSystem, Transform traget)
    {
        float addtionalValue = 0;
        int leveldifferent = 0;

        if (monitoredPlantarySystem(civilSystem, traget))
            addtionalValue += 1;
        else if (monitoredSegmentae(civilSystem, traget, out leveldifferent))
        {
            if (leveldifferent == 0)
                addtionalValue += 0.5f;
            else if (leveldifferent == 1)
                addtionalValue += 0.3f;
            else if (leveldifferent == 2)
                addtionalValue += 0.1f;
        }

        return addtionalValue;
    }

    
    private bool monitoredPlantarySystem(DetectionSystem civilSystem, Transform traget)
    {
        return civilSystem.searchPlanetarySystem(traget.GetComponent<PlanetarySystem>());
    }

    
    private bool monitoredSegmentae(DetectionSystem civilSystem, Transform traget, out int levelDifference)
    {
        StarsSegmentae segmentae = StarsSegmentaeSpawn.SpawnInstance.fingSegmentae(traget.GetComponent<PlanetarySystem>());
        levelDifference = 0;
        do
        {
            if (civilSystem.searchSegmentae(segmentae) == true)
                return true;

            levelDifference++;
            segmentae.getUpperSegmentae();
        } while (segmentae != null);

        return false;
    }
    

    /// <summary>
    /// 计算观测目标和玩家行星系的距离，并根据距离计算 ConcealmentParameter
    /// </summary>
    /// <param name="target">观测目标</param>
    /// <param name="playerDectionSystem">玩家行星系</param>
    /// <returns>ConcealmentParameter</returns>
    private float calculateDistanceAffect(Transform target, Transform playerDectionSystem)
    {
        float concealmentParameter = (float) Vector3.Distance(target.position, playerDectionSystem.position) * 0.03f;
         return concealmentParameter;
    }

    private void generateDectionError(float dectionParameter)
    {
        if (dectionParameter < 0)
        {
            int level = differentValueLevel(Mathf.Abs(dectionParameter));
            if (level == 1)
            {
                detectionError.setPlanetsNum(1);
            }
            else if (level == 2)
            {
                detectionError.setPlanetsNum(2);
            }
            else
            {
                detectionError.setPlanetsNum(3);
            }
                
        }
        OnSendingDetectionError(detectionError);
    }

    /// <summary>
    /// 根据探测参数和隐藏参数的差值，返回误差等级
    /// </summary>
    /// <param name="D_value">探测参数和隐藏参数的差值（绝对值）</param>
    /// <returns>误差等级</returns>
    private int differentValueLevel(float D_value)
    {
        if (D_value < 0.5)
            return 1;
        else if (D_value < 1.2)
            return 2;
        else
            return 3;
    }

    private bool dectionParameterBigger(float concealmentParameter, float dectionParameter)
    {
        if (concealmentParameter > dectionParameter)
            return false;
        else
            return true;
    }

}
