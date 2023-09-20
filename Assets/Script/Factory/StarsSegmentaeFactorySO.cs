using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StarsSegmentaeFactory", menuName = "SO/Factory/StarsSegmentaeFactory")]
public class StarsSegmentaeFactorySO : ScriptableObject
{
    [SerializeField] private StarsSegmentae starsSegmentae;
    [SerializeField] private SmallSegmentae smallSegmentae;

    [SerializeField] private List<SegmentaeAreaSO> segmentaeAreas;
    [SerializeField] private List<ScaleOfSegmentaeSO> segmentaeScales;


    public StarsSegmentae creatLargeSegmentae(Vector3 position, float heavyElementConcentration)
    {
        initializationAttribute(position, starsSegmentae, heavyElementConcentration, segmentaeAreas[2]);
        return Instantiate(starsSegmentae);
    }

    public StarsSegmentae creatOtherStarsSegmentae(Vector3 position, StarsSegmentae parentSegmentae,float heavyElementConcentration)
    {
        
        initializationAttribute(position,starsSegmentae, heavyElementConcentration, segmentaeAreas[1]);
        setSegmentaeRelation(parentSegmentae, starsSegmentae);
        return Instantiate(starsSegmentae);
    }

    public SmallSegmentae creatSmallSegmentae(Vector3 position, StarsSegmentae parentSegmentae, float heavyElementConcentration)
    {
        initializationAttribute(position, smallSegmentae, heavyElementConcentration, segmentaeAreas[0]);
        setSegmentaeRelation(parentSegmentae, smallSegmentae);
        return Instantiate(smallSegmentae);
    }

    private void initializationAttribute(Vector3 position,StarsSegmentae segmentae, float heavyElementConcentration,SegmentaeAreaSO area)
    {
        segmentae.setHeavyElementConcentration(heavyElementConcentration);
        segmentae.transform.position = position;
        segmentae.setArea(area);
    }

    private void setSegmentaeRelation(StarsSegmentae parentSegmentae, StarsSegmentae currentSegmentae)
    {
        currentSegmentae.setUpperSegmentae(parentSegmentae);
        parentSegmentae.addLowerSegmentae(currentSegmentae);
    }
}
