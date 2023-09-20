using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;

    [SerializeField]private ProflieTextInforSO textInfor;

    [SerializeField]private List<AbnormalProfileTypeSO> AbnormalprofileTypes;

    private void Start()
    {
        instance = this;
    }

    public void getAbnormalProfile(StarsSegmentae segmentae,CivilizationSO civilization)
    {
        AbnormalProflie proflie = new AbnormalProflie();
        setAbnormalData(segmentae,proflie);

        getCivilProfileCollections(civilization).addAbnormalProfile(proflie);
    }

    /// <summary>
    /// （是否修改data存疑）
    /// </summary>
    /// <param name="segmentae"></param>
    /// <param name="proflie"></param>
    private void setAbnormalData(StarsSegmentae segmentae, AbnormalProflie proflie)
    {
        proflie.setSegmentae(segmentae);
        proflie.setType(AbnormalprofileTypes[0]);
    }

    private CivilProfileCollectionsSO getCivilProfileCollections(CivilizationSO civilization)
    {
        return civilization.GetCivilArchives().getCivilProfileCollections();
    }

    public AbnormalProfileTypeSO getAbnormalProfileType(int index)
    {
        if (index < AbnormalprofileTypes.Count)
            return AbnormalprofileTypes[index];
        else
            return null;
    }
    
}
