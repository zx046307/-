using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyControl : MonoBehaviour
{
    public static int moneys;
    public int money = 200;
    public Slider moneySlider;
    public static int treament = 1000;
    // Start is called before the first frame update
    void Start()
    {
        moneys = money;
        moneySlider.value = money;
    }

    // Update is called once per frame
    void Update()
    {
        moneySlider.value = moneys;
    }
}
