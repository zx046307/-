using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controler : MonoBehaviour
{
    Animator Animations_Control;
    CharacterController Player_Control;
    // Start is called before the first frame update
    void Start()
    {
        Animations_Control = GetComponent<Animator>();
        Player_Control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float UpDown = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.LeftShift))
            UpDown *= 2;
        Animations_Control.SetFloat("Speed",UpDown);

        float LeftRight = Input.GetAxis("Horizontal");
        Animations_Control.SetFloat("Direction", LeftRight, 0.15f, Time.deltaTime);

        if(Input.GetKey(KeyCode.Space))
            Animations_Control.SetBool("Start Attack",true);
        else
            Animations_Control.SetBool("Start Attack",false);
    }
}
