using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject penal1;
    public GameObject penal2;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        Time.timeScale = 0;
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        penal1.SetActive(false);
        penal2.SetActive(true);
        MoneyControl.treament = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
