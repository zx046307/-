using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        blood.value = lives;
    }
}
