using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int m_seconds;

    public int m_min;
    public int m_sec;

    public Text m_timer;
    public GameObject BagPanel;

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        m_seconds = (m_min * 60) + m_sec;

        while (m_seconds > 0)
        {
            yield return new WaitForSeconds(1);

            m_seconds--;
            m_sec--;

            if (m_sec < 0 && m_min > 0)
            {
                m_min -= 1;
                m_sec = 59;
            }
            else if (m_sec < 0 && m_min == 0)
            {
                m_sec = 0;
            }
            m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        }

        yield return new WaitForSeconds(1);
        BagPanel.SetActive(true);
        Time.timeScale = 0;
    }
}

