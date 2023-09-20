using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalProflie : Profile
{
    private StarsSegmentae segmentae;
    private string description;
    private AbnormalProfileTypeSO type;

    public string getDescription()
    {
        return description;
    }

    public void setDescription(string text)
    {
        description = text;
    }

    public StarsSegmentae getSegmentae()
    {
        return segmentae;
    }

    public void setSegmentae(StarsSegmentae segmentae)
    {
        this.segmentae = segmentae;
    }

    public void setType(AbnormalProfileTypeSO type)
    {
        this.type = type;
    }

    public AbnormalProfileTypeSO getType()
    {
        return type;
    }
}
