using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumegame : MonoBehaviour
{
    public GameObject BagPanel;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick ()
    {
        Time.timeScale=1;
        BagPanel.SetActive(!BagPanel.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}