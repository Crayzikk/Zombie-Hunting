using UnityEngine;

public class Timer
{
    public float countdownTime { get; set; }
    private float timer;

    public Timer() : this(1f) { }

    public Timer(float time)
    {
        countdownTime = time;
        timer = countdownTime;
    }
    
    public delegate void TimerAction();

    public void RunTimer(TimerAction action)
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            action();
            timer = countdownTime; 
        }
    }
}
