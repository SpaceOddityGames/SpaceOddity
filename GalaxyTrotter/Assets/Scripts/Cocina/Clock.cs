using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject palitoPivot;
    public int MAXTIME = 30;
    private float actualTime;
    private float timeScale = 1;
    private float timePorcentaje;
    private Transform initPos;
    public bool timerOn;
    private bool soundPlaying;

    private float frameRateWithTimeScale = 0f;
    void Start()
    {
        //palitoPivot.transform.position = this.transform.position;
        initPos = palitoPivot.transform;
        actualTime = 0;
        timerOn = false;
        soundPlaying = false;
    }
    void Update()
    {
        if (timePorcentaje < 100 && timerOn)
        {
            frameRateWithTimeScale = Time.deltaTime * timeScale;
            actualTime += frameRateWithTimeScale;
            timePorcentaje = actualTime * 100 / MAXTIME;
            palitoPivot.transform.rotation = (Quaternion.Euler(timePorcentaje * 360 / 100, 90, -90));
            if(MAXTIME-actualTime <= 6 && !soundPlaying) 
            {
                soundPlaying = true;
                FindObjectOfType<AudioManager>().Play("timer");
            }
        }
    }
    public bool comprobateTimer()
    {
        if (timePorcentaje < 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void resetTimer()
    {
        actualTime = 0;
        timePorcentaje = 0;
        soundPlaying = false;
        palitoPivot.transform.position = initPos.position;
        palitoPivot.transform.rotation = initPos.rotation;
    }
    public void setMaxTime(int newMax)
    {
        MAXTIME = newMax;
    }
    public void start()
    {
        timerOn = true;
    }
    public void stop()
    {
        timerOn = false;
    }
}
