using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSave : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick ()
    {
        PlayerPrefs.SetInt("EXP",0);
        PlayerPrefs.SetInt("Tower1_Level",0);
        PlayerPrefs.SetInt("Tower2_Level",0);
        PlayerPrefs.SetInt("Tower3_Level",0);
    }
    void Update()
    {
        
    }
}
