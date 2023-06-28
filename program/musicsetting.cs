using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class musicsetting : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioMixer;

    public void ControlMainVolume(float v)
    {
        audioMixer.SetFloat("Main", v);
    }
    public void ControlBgmVolume(float v)
    {
        audioMixer.SetFloat("BGM",v);
    }
    public void ControlTexiaoVolume(float v)
    {
        audioMixer.SetFloat("SoundEffect", v);
    }
}