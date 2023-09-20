using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeString;
    public string path;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        panelType = type;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}
