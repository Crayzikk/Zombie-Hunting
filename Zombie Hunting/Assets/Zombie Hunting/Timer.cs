using UnityEngine;

public class Timer
{
    public float countdownTime { get; set; }
    private float timer;
    private bool firstCall = true;
    private bool firstTimerStart = false;

    public Timer() : this(1f) { }

    public Timer(float time)
    {
        InitializeTimer(time);
    }

    public Timer(float time, bool state)
    {
        InitializeTimer(time);
        firstTimerStart = state;
    }    
    
    public delegate void TimerAction();

    public void RunTimer(TimerAction action)
    {
        if (firstCall && firstTimerStart)
        {
            action();
            firstCall = false;
        }
        else
        {
            timer -= Time.deltaTime;

            if(timer <= 0f)
            {
                action();
                timer = countdownTime; 
            }
        }
    }

    private void InitializeTimer(float time)
    {
        countdownTime = time;
        timer = countdownTime;
    }
}
