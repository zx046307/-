using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatelingGun : MonoBehaviour
{
    private Transform target;//鎖定標籤
    [Header("Attributes")]
    public float range = 15f;//攻擊範圍
    public float fireRate = 1f;//攻擊速度
    private float fireCountdown=0f;//攻擊間隔
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";//標籤名稱
    public Transform partTorotate; //轉向模型
    public float turnSpeed = 10f;//轉向速度

    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget()//鎖定敵人
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        //轉向控制
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partTorotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partTorotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
        //攻擊控制
        if(fireCountdown<=0f)
        {
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()//生成子彈
    {
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Bullet bullet =bulletObject.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.seek(target);
        }
    }

    void OnDrawGizmodSelecter()//鎖定範圍繪製
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
