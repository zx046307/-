using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;//速度
    private Transform target;//位置資訊
    private int wavepointIndex = 0;//路標點

    void Start()
    {
        target = waypoint.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;//移動向路標點
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<=0.4f)//到達路標點換下一個路標點
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()//切換路標點
    {
        if(wavepointIndex>=waypoint.points.Length-1)//到達終點吹毀自己
        {
            endPoint();
            return;
        }

        wavepointIndex++;
        target = waypoint.points[wavepointIndex];
    }

    void endPoint()
    {
        BloodControl.lives--;
        Destroy(gameObject);
    }
}
