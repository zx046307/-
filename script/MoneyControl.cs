using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//金錢設定
public class MoneyControl : MonoBehaviour
{
    public static int moneys;
    public int money = 200;
    public Slider moneySlider;
    public static int treament = 1000;
    void Start()
    {
        moneys = money;
        moneySlider.value = money;
    }
    void Update()
    {
        moneySlider.value = moneys;
    }
}
