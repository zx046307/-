using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//戰敗設定
public class defeatCastle : MonoBehaviour
{
    public GameObject fail;
    public Slider CastleBlood;
    void Update()
    {
        if(CastleBlood.value<=0)
        {
            fail.SetActive(true);
            Time.timeScale=0;
        }
    }
}
