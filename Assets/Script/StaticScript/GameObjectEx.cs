using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 为整个游戏提供方法
/// </summary>
public static class GameObjectEx 
{
    /// <summary>
    /// 通过lineRender画一个圆
    /// </summary>
    /// <param name="container">装载lineRender的对象</param>
    /// <param name="radius">这个圆的半径</param>
    /// <param name="lineWidth">这个圆线条的粗细</param>
    public static void DrawCircle(this GameObject container, float radius, float lineWidth, Transform parentTransform)
    {
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.startColor = Color.black;
        line.positionCount = segments + 1;

        var pointCount = segments + 1;
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        line.SetPositions(points);
        line.transform.SetParent(parentTransform);
    }

    /// <summary>
    /// 将现实的距离数据转化为unity场景的距离
    /// </summary>
    /// <param name="realDistance">现实中的距离</param>
    /// <returns>unity 场景中的距离</returns>
    public static float distanceTransformation(int realDistance)
    {
        return 50f;
    }

    /// <summary>
    /// 返回鼠标点击物体的引用
    /// </summary>
    /// <returns>鼠标点击物体的 Transform</returns>
    public static Transform selectObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform;
        }

        return null;
        
    }

    /*
    public static void passedTime(int time)
    {
        float i = 0;
        while (i < time)
        {
            i += Time.deltaTime;
            Debug.Log(i);
        }


    }
    */

}
