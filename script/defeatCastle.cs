using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//戰敗設定
public class defeatCastle : MonoBehaviour
{
    public GameObject fail;
    public Text EXP_Text;
    public Slider CastleBlood;
    int EXP=0;
    int total=0;
    int n=0;
    void Start()
    {
        total=PlayerPrefs.GetInt("EXP");
    }
    void Update()
    {
        if(CastleBlood.value<=0)
        {
            final();
            fail.SetActive(true);
            Time.timeScale=0;
        }
    }
    void final()
    {
        if(n==0)
        {
            EXP+=wavespawner.WaveCount*10;
            EXP_Text.text=EXP.ToString();
            total+=EXP;
            PlayerPrefs.SetInt("EXP",total);
            n=1;
        }
    }
}
