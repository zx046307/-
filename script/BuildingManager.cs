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
    public bool canPlace = true;//是否可放置
    [SerializeField] private LayerMask layerMask;//放置層限定
    [SerializeField] private Material[] materials;//材質設定

    private void Update()
    {
        if(pendingObj != null)
        {
            pendingObj.transform.position = pos;
            if(Input.GetMouseButtonDown(0) && canPlace)//放下建築條件控制
            {
              placeObject();
              SwitchObj.SwitchControl=1;//建築控制用
            }
            UpdateMaterials();
        }
    }

    void placeObject()
    {
      pendingObj.GetComponent<MeshRenderer>().material = materials[2];
      pendingObj = null;
    }

    private void FixedUpdate()//滑鼠位置
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask))//位置為滑鼠指向，限定layer
        {
            pos = hit.point;
        }
    }

    public void SelectObject(int index)//選擇建築
    {
      if(moneyslider.value>=money[index])//金錢判定&生成建築
      {
        pendingObj = Instantiate(objects[index], pos, transform.rotation);
        SwitchObj.SwitchControl=0;
        text.SetActive(false);
        MoneyControl.moneys-=money[index];
      }
      else
      {
        text.SetActive(true);
      }
    }

    void UpdateMaterials()//材質設定
    {
      if(canPlace)
      {
        pendingObj.GetComponent<MeshRenderer>().material = materials[0];//能放置
      }
      else
      {
        pendingObj.GetComponent<MeshRenderer>().material = materials[1];//不能放置
      }
    }
}
