using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPSystem : MonoBehaviour
{
    public Text EXP_Text;
    public Text Tower1_EXP_Text;
    public Text Tower2_EXP_Text;
    public Text Tower3_EXP_Text;
    public Text Tower1_Level_Text;
    public Text Tower2_Level_Text;
    public Text Tower3_Level_Text;
    public GameObject CannotUpgrade;
    private int EXP=0;
    private int Tower1_EXP=1000;
    private int Tower2_EXP=1000;
    private int Tower3_EXP=1000;
    private int Tower1_Level=0;
    private int Tower2_Level=0;
    private int Tower3_Level=0;
    void Start()
    {
        EXP=PlayerPrefs.GetInt("EXP");
        Tower1_Level=PlayerPrefs.GetInt("Tower1_Level");
        Tower2_Level=PlayerPrefs.GetInt("Tower2_Level");
        Tower3_Level=PlayerPrefs.GetInt("Tower3_Level");
        Tower1_EXP+=Tower1_Level*250;
        Tower2_EXP+=Tower2_Level*250;
        Tower3_EXP+=Tower3_Level*250;
    }
    void Update()
    {
        EXP_Text.text=EXP.ToString();
        Tower1_EXP_Text.text=Tower1_EXP.ToString();
        Tower2_EXP_Text.text=Tower2_EXP.ToString();
        Tower3_EXP_Text.text=Tower3_EXP.ToString();
        Tower1_Level_Text.text=Tower1_Level.ToString();
        Tower2_Level_Text.text=Tower2_Level.ToString();
        Tower3_Level_Text.text=Tower3_Level.ToString();
    }
    public void Upgrade1()
    {
        if(EXP>=Tower1_EXP)
        {
            EXP-=Tower1_EXP;
            Tower1_Level+=1;
            Tower1_EXP+=250;
            CannotUpgrade.SetActive(false);
        }
        else
        {
            CannotUpgrade.SetActive(true);
        }
    }
    public void Upgrade2()
    {
        if(EXP>=Tower2_EXP)
        {
            EXP-=Tower2_EXP;
            Tower2_Level+=1;
            Tower2_EXP+=250;
            CannotUpgrade.SetActive(false);
        }
        else
        {
            CannotUpgrade.SetActive(true);
        }
    }
    public void Upgrade3()
    {
        if(EXP>=Tower3_EXP)
        {
            EXP-=Tower3_EXP;
            Tower3_Level+=1;
            Tower3_EXP+=250;
            CannotUpgrade.SetActive(false);
        }
        else
        {
            CannotUpgrade.SetActive(true);
        }
    }
    public void reset1()
    {
        if(Tower1_Level>0)
        {
            int total=0;
            for(int i=0;i<Tower1_Level;i++)
            {
                for(int j=0;j<i;j++)
                {
                    total+=250;
                }
            }
            total+=Tower1_Level*1000;
            EXP+=total;
            Tower1_Level=0;
            Tower1_EXP=1000;
        }
    }
    public void reset2()
    {
        if(Tower2_Level>0)
        {
            int total=0;
            for(int i=0;i<Tower2_Level;i++)
            {
                for(int j=0;j<i;j++)
                {
                    total+=250;
                }
            }
            total+=Tower2_Level*1000;
            EXP+=total;
            Tower2_Level=0;
            Tower2_EXP=1000;
        }
    }
    public void reset3()
    {
        if(Tower3_Level>0)
        {
            int total=0;
            for(int i=0;i<Tower3_Level;i++)
            {
                for(int j=0;j<i;j++)
                {
                    total+=250;
                }
            }
            total+=Tower3_Level*1000;
            EXP+=total;
            Tower3_Level=0;
            Tower3_EXP=1000;
        }
    }
    public void save()
    {
        PlayerPrefs.SetInt("EXP",EXP);
        PlayerPrefs.SetInt("Tower1_Level",Tower1_Level);
        PlayerPrefs.SetInt("Tower2_Level",Tower2_Level);
        PlayerPrefs.SetInt("Tower3_Level",Tower3_Level);
    }
}
