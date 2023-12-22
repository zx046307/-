using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private Transform target;//敵人標籤
    public float speed=70f;//子彈速度
    public float exploreRange = 0f;//爆炸範圍
    public GameObject effect;//傷害特效
    int damage1=0;
    int damage2=0;
    int n=0;
    private int Tower1_Level=0;
    private int Tower2_Level=0;

    public void seek(Transform _target)//標籤設定
    {
        target=_target;
    }

    void Update()
    {
        if(n==0)
        {
            Tower1_Level=PlayerPrefs.GetInt("Tower1_Level");
            Tower2_Level=PlayerPrefs.GetInt("Tower2_Level");
            damage1=damage;
            damage2=damage;
            damage1+=Tower1_Level*5;
            damage2+=Tower2_Level*5;
            n=1;
        }
        if(target == null)//沒擊中目標
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude<=distanceThisFrame)//擊中目標
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()//攻擊判定
    {
        GameObject effectIns = (GameObject)Instantiate(effect,transform.position,transform.rotation);
        Destroy(effectIns,5f);
        if(exploreRange>0f)
        {
            Explode();
        }
        else
        {
            Damage(target,1);
        }
        Destroy(gameObject);
    }
    void Explode()//爆炸判定
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exploreRange);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform,2);
            }
        }
    }
    void Damage(Transform enemy, int selection)//傷害設定
    {
        if(selection==1)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage1,1);
        }
        else if(selection==2)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage2,1);
        }
    }
    void OnDrawGizmodSelected()//爆炸範圍設定
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exploreRange);
    }
}
