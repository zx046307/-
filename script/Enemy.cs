using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;//速度
    public float health = 100;//血量
    public int value = 20;//價值
    private Transform target;//位置資訊
    private int wavepointIndex = 0;//路標點

    void Start()
    {
        target = waypoint.points[0];
    }
    public void TakeDamage(float amount)//傷害判定
    {
        health-=amount;
        if(health<=0)
        {
            Die();
        }
    }
    void Die()//死亡判定
    {
        MoneyControl.moneys+=value;
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;//移動向路標點
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*1000).eulerAngles;
        transform.rotation = Quaternion.Euler(0f,rotation.y,0f);

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
    void endPoint()//到達終點
    {
        BloodControl.lives--;
        Destroy(gameObject);
    }
}
