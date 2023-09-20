using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于存储所有文明所收集的 profile
/// </summary>
[CreateAssetMenu(fileName = "CivilProfileCollections", menuName = "SO/Civilization/Civil/CivilProfileCollections")]
public class CivilProfileCollectionsSO : ScriptableObject
{
    [SerializeField]private List<AbnormalProflie> abnormalProfiles = new List<AbnormalProflie>();

    public void addAbnormalProfile(AbnormalProflie profile)
    {
        abnormalProfiles.Add(profile);
    }

    public AbnormalProflie getAbnormalProfile(int index)
    {
        return abnormalProfiles[index];
    }
}
