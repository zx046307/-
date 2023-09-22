using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//建築系統
public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects; //掛預置檔
    public int[] money;//金額設定
    private GameObject pendingObj; //複製模型
    public GameObject text;//金錢不夠
    public Slider moneyslider;//總金錢數
    private Vector3 pos;  //位置
    private RaycastHit hit;//滑鼠指向
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
    private void FixedUpdate()//滑鼠位置
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }
    public void SelectObject(int index)//選擇建築
    {
      if(moneyslider.value>=money[index])//金錢判定&生成建築
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
