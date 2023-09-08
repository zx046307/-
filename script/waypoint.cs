using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public static Transform[] points;//路標點位置

    void Awake()
    {
        points = new Transform[transform.childCount];//新增路標點
        for(int i = 0; i<points.Length ; i++)
        {
            points[i] = transform.GetChild(i);//下一個路標點
        }
    }
}
