using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject restartButton;
    public GameObject penal;
    public GameObject penal1;
    public GameObject penal2;
    public GameObject penal3;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        Time.timeScale = 0;
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        penal.SetActive(false);
        penal1.SetActive(false);
        penal2.SetActive(true);
        penal3.SetActive(false);
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
        MoneyControl.treament = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
