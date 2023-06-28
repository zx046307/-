using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScenesSetting : MonoBehaviour
{
    public string scene;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick ()
    {
        SceneSwitch(scene);
    }
    void Update()
    {
        
    }
    
    public void SceneSwitch(string _SceneName) 
    {
        SceneManager.LoadScene(_SceneName);
    }
}
