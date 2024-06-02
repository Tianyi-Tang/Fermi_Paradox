using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 生成并初始化星域
/// </summary>
public class StarsSegmentaeSpawn : MonoBehaviour
{
    public static StarsSegmentaeSpawn SpawnInstance;

    [SerializeField] private int largeSegmentaeNum;
    [SerializeField] private int middleContinedLarge;//一个大星域含有几个中星域
    [SerializeField] private int smallContinedmiddlle;//一个中星域含有几个小星域

    [SerializeField] private StarsSegmentaeFactorySO starsSegmentaeFactory;

    [SerializeField] private List<ScaleOfSegmentaeSO> segmentaeScales;
    [SerializeField] private List<SegmentaeAreaSO> segmentaeAreas;

    private GameInitializeController controller;

    private List<SmallSegmentae> smallest_segmentaes = new List<SmallSegmentae>();

    private List<StarsSegmentae> biggest_segmentaes = new List<StarsSegmentae>();
    
    private void Awake()
    {
        initialLargeSegmentaes();

        PlanetarySystemSpawn spawner = FindObjectOfType<PlanetarySystemSpawn>();
        spawner.starsSegmentaes = smallest_segmentaes;
        spawner.enabled = true;

        SpawnInstance = this;
    }

    public void wakeSpanwer(SegmentumInfor infor,GameInitializeController controller)
    {
        if(controller != null && !this.enabled)
        {
            largeSegmentaeNum = infor.largeSegmentaeNum;
            middleContinedLarge = infor.middleContinedLarge;
            smallContinedmiddlle = infor.smallContinedmiddlle;
            this.controller = controller;
            this.enabled = true;
        }
    }


    private void initialLargeSegmentaes()
    {
        Vector3 largeSegmentaesPos = new Vector3(0, 0, 0);
        List<Vector3> largeSegmentaes = new List<Vector3>();
        StarsSegmentae largeSegmentae;

        for (int i = 0; i < largeSegmentaeNum; i++)
        {
            largeSegmentaesPos = ensurePosition(segmentaeScales[2], largeSegmentaesPos, largeSegmentaes);
            largeSegmentae = creatLargesegmentaes(largeSegmentaesPos);
            initialMiddleSegmentaes(largeSegmentae);
            biggest_segmentaes.Add(largeSegmentae);
        }
    }

    private void initialMiddleSegmentaes(StarsSegmentae largeSegmentae)
    {
        Vector3 middleSegmentaesPos = new Vector3(0, 0, 0);
        List<Vector3> middleSegmentaes = new List<Vector3>();
        StarsSegmentae middleSegmentae;

        for (int i = 0; i < middleContinedLarge; i++)
        {
            middleSegmentaesPos = ensurePosition(segmentaeScales[2], segmentaeScales[1], largeSegmentae.transform.position, middleSegmentaesPos, middleSegmentaes);
            middleSegmentae = creatMiddleSegmentaes(largeSegmentae, middleSegmentaesPos);
            middleSegmentae.transform.SetParent(largeSegmentae.transform,false);
            initialSmallSegmentaes(middleSegmentae);
        }
    }

    private void initialSmallSegmentaes(StarsSegmentae middleSegmentae)
    {
        Vector3 smallSegmentaesPos = new Vector3(0, 0, 0);
        List<Vector3> smallSegmentaes = new List<Vector3>();
        SmallSegmentae smallSegmentae;

        for (int i = 0; i < smallContinedmiddlle; i++)
        {
            smallSegmentaesPos = ensurePosition(segmentaeScales[1], segmentaeScales[0],middleSegmentae.transform.position, smallSegmentaesPos, smallSegmentaes);
            smallSegmentae = creatSmallSegmentaes(middleSegmentae, smallSegmentaesPos);
            smallSegmentae.transform.SetParent(middleSegmentae.transform,false);
            smallest_segmentaes.Add(smallSegmentae);
        }
    }

    private StarsSegmentae creatLargesegmentaes(Vector3 segmentaesPos)
    {
        StarsSegmentae largeSegmentae = starsSegmentaeFactory.creatLargeSegmentae(segmentaesPos, randomHeavyElementConcentration());
        return largeSegmentae;
    }

    private StarsSegmentae creatMiddleSegmentaes(StarsSegmentae largeSegmentae, Vector3 middleSegmentaesPos)
    {
        StarsSegmentae middleSegmentae = starsSegmentaeFactory.creatOtherStarsSegmentae(middleSegmentaesPos, largeSegmentae, randomHeavyElementConcentration());
        return middleSegmentae;
    }

    private SmallSegmentae creatSmallSegmentaes(StarsSegmentae middleSegmentae, Vector3 smallSegmentaePos)
    {
        SmallSegmentae smallSegmentae = starsSegmentaeFactory.creatSmallSegmentae(smallSegmentaePos, middleSegmentae, randomHeavyElementConcentration());
        return smallSegmentae;
    }

    private Vector3 ensurePosition(ScaleOfSegmentaeSO segmentaeScale,Vector3 segmentaesPos,List<Vector3> previousSegmentaes)
    {
        float radius = getRadius(segmentaeScale);

        while (true)
        {
            //segmentaesPos.Set(Random.Range(0,5), 0, Random.Range(1,6));//该数据仅供测试，后续需要调整
            if (previousSegmentaes.Count == 0)
            {
                previousSegmentaes.Add(segmentaesPos);
                return segmentaesPos;
            }
            else
            {
                if (checkDistance(segmentaesPos, previousSegmentaes, radius) == true)
                {
                    previousSegmentaes.Add(segmentaesPos);
                    return segmentaesPos;
                }
            }
        }
    }

    
    private Vector3 ensurePosition(ScaleOfSegmentaeSO parentScale, ScaleOfSegmentaeSO childScale, Vector3 parentPos, Vector3 childPos, List<Vector3> childSegmentaesPos)
    {
        float parentRadius = getRadius(parentScale);
        float childRadius = getRadius(childScale);


        while (true)
        {
            //childPos.Set(Random.Range(-1.5f * parentRadius, 1.5f * parentRadius), 0, Random.Range( -1.5f * parentRadius, 1.5f * parentRadius));
            if (childSegmentaesPos.Count == 0)
            {
                childSegmentaesPos.Add(childPos);
                return childPos;
            }
            else
            {
                if (checkDistance(parentPos, childPos, childSegmentaesPos, parentRadius, childRadius))
                {
                    childSegmentaesPos.Add(childPos);
                    return childPos;
                }
            }
        }
    }
    


    /// <summary>
    /// 供相同大小的 Segmentae 检查是否有足够距离
    /// </summary>
    /// <param name="segmentaesPos">segmentaes 的位置</param>
    /// <param name="previousSegmentaes">所有已经存在 segmentaes 的位置</param>
    /// <param name="radius">要求最短相隔的距离</param>
    /// <returns></returns>
    private bool checkDistance(Vector3 segmentaesPos, List<Vector3> previousSegmentaes,float radius)
    {
        for (int i = 0; i < previousSegmentaes.Count; i++)
        {
            float distance = Vector3.Distance(segmentaesPos, previousSegmentaes[i]);
            if (distance < radius*2)
                return false;
        }
        return true;
    }

    /// <summary>
    /// 供不同大小的 Segmentae 检查是否有足够的距离
    /// </summary>
    /// <param name="parentPos"></param>
    /// <param name="childPos"></param>
    /// <param name="childSegmentaesPos"></param>
    /// <param name="parentRadius"></param>
    /// <param name="childRadius"></param>
    /// <returns></returns>
    private bool checkDistance(Vector3 parentPos, Vector3 childPos, List<Vector3> childSegmentaesPos, float parentRadius, float childRadius)
    {
        float parent_distance = Vector3.Distance(parentPos, childPos);

        for (int i = 0; i < childSegmentaesPos.Count; i++)
        {
            float child_distance = Vector3.Distance(childPos, childSegmentaesPos[i]);
            if (parent_distance < parentRadius + childRadius && child_distance < childRadius * 2)
                return false;
        }
        return true;
    }

    private float getRadius(ScaleOfSegmentaeSO segmentaeScale)
    {
        float radius;
        if (segmentaeScales[0] == segmentaeScale)
            radius = segmentaeAreas[0].getRadius();
        else if (segmentaeScales[1] == segmentaeScale)
            radius = segmentaeAreas[1].getRadius();
        else
            radius = segmentaeAreas[2].getRadius();
        return radius;
    }

   
    /// <summary>
    /// 随机 Segmentae 中重元素的比例（暂时替代，后续需改进）
    /// </summary>
    /// <returns></returns>
    private float randomHeavyElementConcentration()
    {
        return Random.Range(1.0f, 0);
    }

    
    public SmallSegmentae fingSegmentae(PlanetarySystem planetary)
    {
        foreach (SmallSegmentae segmentae in smallest_segmentaes)
        {
            if (segmentae.findPlanetarySystem(planetary))
                return segmentae;
            
        }
        return null;
    }

    public int getBiggest_segmentaes()
    {
        return biggest_segmentaes.Count;
    }

    public StarsSegmentae StarsSegmentae(int index)
    {
        if (index < biggest_segmentaes.Count)
            return biggest_segmentaes[index];
        else
            return null;
    }





}
