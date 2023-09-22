using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;//敵人標籤
    public float speed=70f;//子彈速度
    public float exploreRange = 0f;//爆炸範圍
    public GameObject effect;//傷害特效

    public void seek(Transform _target)//標籤設定
    {
        target=_target;
    }

    void Update()
    {
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
            enemy.GetComponent<Enemy>().TakeDamage(25);
        }
        else if(selection==2)
        {
            enemy.GetComponent<Enemy>().TakeDamage(35);
        }
    }
    void OnDrawGizmodSelected()//爆炸範圍設定
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exploreRange);
    }
}
