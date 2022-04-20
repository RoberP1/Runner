using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timertext;

    private float startTime;
    private string time;

    private bool finalizo;
    void Start()
    {
        startTime = Time.time;
    }


    void Update()
    {
        if (finalizo) return;
        
            float t = Time.time - startTime;
            string Minutos = ((int)t / 60).ToString();
            string Segundos = (t % 60).ToString("f2");

            if ((t % 60) < 10)
            {
                time = Minutos + ":0" + Segundos;
                timertext.text = time;
            }
            else
            {
                time = Minutos + ":" + Segundos;
                timertext.text = time;
            }
        

    }
    public void Stop()
    {
        finalizo = true;
    }
    public string GetTime()
    {
        return time;
    }
}