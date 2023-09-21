using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;//敵人標籤
    public float speed=70f;//子彈速度
    public float exploreRange = 0f;
    public GameObject effect;

    public void seek(Transform _target)
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
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(effect,transform.position,transform.rotation);
        Destroy(effectIns,5f);
        if(exploreRange>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, exploreRange);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    void OnDrawGizmodSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exploreRange);
    }
}
