using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects; //掛預置檔
    public int[] money;//金額設定
    private GameObject pendingObj; //複製模型
    public GameObject text;
    public Slider moneyslider;//總金錢數
    private Vector3 pos;  //位置
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    private void Update()
    {
        if(pendingObj != null)
        {
            pendingObj.transform.position = pos;
            if(Input.GetMouseButtonDown(0))
            {
              placeObject();
            }
        }
    }
    void placeObject()
    {
        pendingObj = null;
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }
    public void SelectObject(int index)
    {
      if(moneyslider.value>=money[index])
      {
        pendingObj = Instantiate(objects[index], pos, transform.rotation);
        text.SetActive(false);
        MoneyControl.moneys-=money[index];
      }
      else
      {
        text.SetActive(true);
      }
    }
}
