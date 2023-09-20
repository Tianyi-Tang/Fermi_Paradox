using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星域囊括的面积
/// </summary>
[CreateAssetMenu(fileName = "SegmentaeArea", menuName = "SO/Stars/Segmentaes/SegmentaeArea")]
public class SegmentaeAreaSO : ScriptableObject
{
    [SerializeField] private float radius;

    public float getRadius()
    {
        return radius;
    }
}
