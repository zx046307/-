using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodTreatment : MonoBehaviour
{
    public Text cost;
    public int treatment_live;
    public void OnClick()
    {
        MoneyControl.moneys-=MoneyControl.treament;
        MoneyControl.treament+=500;
        BloodControl.lives = treatment_live;
        cost.text = MoneyControl.treament.ToString();

    }
}
