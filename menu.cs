using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject BagPanel;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick ()
    {
        BagPanel.SetActive(!BagPanel.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
