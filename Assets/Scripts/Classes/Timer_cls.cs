using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer_cls : MonoBehaviour
{
    public float timeRemaining = 10;
    public void ExecuteTime()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public bool TimerIsEnd() { return timeRemaining <= 0; }
}