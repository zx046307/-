using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject BagPanel;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick ()
    {
        BagPanel.SetActive(true);
    }
}
