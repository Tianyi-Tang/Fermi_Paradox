using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 分辨游戏数值类型的class
/// 
/// 注意该 class 的 inspector被修改过，如果想要让 inspector 显示任何新增内容，请去 GameStatsEditor 中修改
/// </summary>
[CreateAssetMenu(fileName ="GameStats",menuName ="SO/Game Stats")]
public class GameParameterSO : ScriptableObject
{
    [SerializeField] private bool hasSpecificName = false;
    [SerializeField] private string specificName = null;

    [SerializeField] private bool isfloat = true;

    public string getSpecificName()
    {
        return specificName;
    }

    public bool isValueFloat()
    {
        return isfloat;
    }
}
