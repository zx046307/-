using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//回血系統
public class BloodTreatment : MonoBehaviour
{
    public Text cost;
    public GameObject text;
    public int treatment_live;
    public void OnClick()
    {
        if(MoneyControl.moneys>=MoneyControl.treament)
        {
            MoneyControl.moneys-=MoneyControl.treament;
            MoneyControl.treament+=500;
            BloodControl.lives = treatment_live;
            cost.text = MoneyControl.treament.ToString();
            text.SetActive(false);
        }
        else
        {
            text.SetActive(true);
        }
    }
}
