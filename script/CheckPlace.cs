using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlace : MonoBehaviour
{
    private BuildingManager buildingManager;

    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    private void OnTriggerEnter(Collider box)
    {
        if(box.gameObject.CompareTag("Tower"))
        {
            buildingManager.canPlace =  false;
        }
    }

    private void OnTriggerExit(Collider box)
    {
        if(box.gameObject.CompareTag("Tower"))
        {
            buildingManager.canPlace =  true;
        }
    }
}
