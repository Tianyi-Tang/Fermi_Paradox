using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 除最小星域的通用class
/// </summary>
public class StarsSegmentae : MonoBehaviour
{
    [SerializeField] protected StarsSegmentae upperSegmentae;
    [SerializeField] private List<StarsSegmentae> lowerSegmentae;

    [SerializeField] protected SegmentaeAreaSO area;

    private float heavyElementConcentration;

    
    public void setArea(SegmentaeAreaSO area)
    {
        this.area = area;
    }

    public float getRadius()
    {
        return area.getRadius();
    }

    public void setHeavyElementConcentration(float heavyElementConcentration)
    {
        this.heavyElementConcentration = heavyElementConcentration;
    }

    public void setUpperSegmentae(StarsSegmentae parentSegmentae)
    {
        upperSegmentae = parentSegmentae;
    }

    public void addLowerSegmentae(StarsSegmentae childSegmentae)
    {
        if (lowerSegmentae == null)
            lowerSegmentae = new List<StarsSegmentae>();
            
        lowerSegmentae.Add(childSegmentae);
    }

    public StarsSegmentae getUpperSegmentae()
    {
        return upperSegmentae;
    }

    public int getLowerSegmentaeNum()
    {
        return lowerSegmentae.Count;
    }

    public StarsSegmentae getLowerSegmentae(int index)
    {
        if (index < lowerSegmentae.Count)
            return lowerSegmentae[index];
        else
            return null;
    }

}