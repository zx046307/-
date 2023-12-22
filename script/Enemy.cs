using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;//速度
    public float health = 100;//血量
    public int value = 20;//價值
    public float DamageReduce=0;//減傷
    private Transform target;//位置資訊
    private int wavepointIndex = 0;//路標點
    int wavecount=0;
    int laserdamage=0;
    private int Tower3_Level=0;
    void Start()
    {
        Tower3_Level=PlayerPrefs.GetInt("Tower3_Level");
        DamageReduce=0;
        target = waypoint.points[0];
        laserdamage=Tower3_Level*5;
        laserdamage+=60;
    }
    public void TakeDamage(float amount,int n)//傷害判定
    {
        if(n==1)
        {
            if(amount<=DamageReduce)
            {
                health-=0;
            }
            else
            {
                float TrueDamage=0;
                TrueDamage=amount-DamageReduce;
                health-=TrueDamage;
            }
        }
        if(n==2)
        {
            if(DamageReduce<=laserdamage)
            health-=amount;
        }
        if(health<=0)
        {
            Die();
        }
    }
    public void reset(int i)
    {
        health=i;
    }
    public void nextWave()
    {
        wavecount+=1;
        health+=10;
        if(wavecount%3==0)
        {
            DamageReduce+=1;
        }
    }
    void Die()//死亡判定
    {
        MoneyControl.moneys+=value;
        wavespawner.EnemiesAlive--;
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
        wavespawner.EnemiesAlive--;
        BloodControl.lives--;
        Destroy(gameObject);
    }
}
