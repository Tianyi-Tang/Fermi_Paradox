using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProflieTextInfor", menuName = "SO/Civilization/Profile/ProflieTextInfor")]
public class ProflieTextInforSO : ScriptableObject
{
    [SerializeField]private List<string> abnormalDescriptionText;

    [SerializeField] private string civilDescriptionText;

    public string getAbnotmalDescription(int index)
    {
        if (index < abnormalDescriptionText.Count)
            return abnormalDescriptionText[index];
        else
            return null;
    }
}
