using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money : MonoBehaviour
{
    public Text Text;
    public Slider moneySlider;
    
    void Update()
    {
        Text.text = "金錢數:"+moneySlider.value.ToString();
    }
}
