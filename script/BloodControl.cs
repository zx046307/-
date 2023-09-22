using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//血量控制
public class BloodControl : MonoBehaviour
{
    public static int lives;
    public int live = 100;
    public Slider blood;
    void Start()
    {
        lives = live;
        blood.maxValue= live;
        blood.value= live;
    }
    void Update()
    {
        blood.value = lives;
    }
}
