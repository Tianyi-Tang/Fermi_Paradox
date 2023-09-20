using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 针对不同的文明记录科技的解锁和激活状态
/// </summary>
public class TechnologyState
{
    private bool active = false;//是否激活
    private bool unlocked = false;//是否解锁

    public void activeTechnology()
    {
        active = true;
    }

    public void deactiveTechnology()
    {
        active = false;
    }

    public bool getActiveState()
    {
        return active;
    }

    public void unlockedTechnology()
    {
        unlocked = true;
    }

    public void lockedTechnology()
    {
        unlocked = false;
    }

    public bool getUnlockedState()
    {
        return unlocked;
    }
}
