using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defeatCastle : MonoBehaviour
{
    public GameObject fail;
    public Slider CastleBlood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CastleBlood.value<=0)
        {
            fail.SetActive(true);
            Time.timeScale=0;
        }
    }
}
