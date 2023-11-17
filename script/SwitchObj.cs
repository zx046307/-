using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObj : MonoBehaviour
{
    public static int SwitchControl=0;
    public Transform obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switchObj(SwitchControl);
    }

    void switchObj(int n)
    {
        if(n==1)
        {
            Instantiate(obj, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
