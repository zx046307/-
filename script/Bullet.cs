using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;//敵人標籤
    public float speed=70f;//子彈速度
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
        if(dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(effect,transform.position,transform.rotation);
        Destroy(effectIns,2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
