using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAndSell : MonoBehaviour
{
    public int cost;
    public int sell;
    public Transform Upgradeobj;
    public void Upgrade()
    {
        if(MoneyControl.moneys>=cost)
        {
            MoneyControl.moneys-=cost;
            Instantiate(Upgradeobj, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Sell()
    {
        MoneyControl.moneys+=sell;
        Destroy(gameObject);
    }

    public void DestroyObj()
    {
        if(MoneyControl.moneys>=cost)
        {
            MoneyControl.moneys-=cost;
            Destroy(gameObject);
        }
    }
}
