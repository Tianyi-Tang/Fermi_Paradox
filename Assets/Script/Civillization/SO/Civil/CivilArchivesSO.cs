using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 包含了文明的科技，遇见的文明，难题和文明属性
/// </summary>
[CreateAssetMenu(fileName = "CivilArchives", menuName = "SO/Civilization/Civil/CivilArchives")]
public class CivilArchivesSO : ScriptableObject
{
    [SerializeField]private CivilCognitiveRecordSO civilCognitiveRecord;
    [SerializeField] private CivilProfileCollectionsSO civilProfileCollections;


    public CivilCognitiveRecordSO getCivilCognitiveRecord()
    {
        return civilCognitiveRecord;
    }

    public CivilProfileCollectionsSO getCivilProfileCollections()
    {
        return civilProfileCollections;
    }




}
