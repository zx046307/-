using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodTreatment : MonoBehaviour
{
    public Text cost;
    public void OnClick()
    {
        MoneyControl.moneys-=MoneyControl.treament;
        MoneyControl.treament+=500;
        cost.text = MoneyControl.treament.ToString();

    }
}
