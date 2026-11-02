using System;
using UnityEngine;

public class ReadyTimer : MonoBehaviour
{
    [SerializeField] private float readyTimer = 4;
    private bool readyTimerStop = false;
    public static event Action ReadyTimerEnd;


    void Update()
    {
        if (readyTimerStop) return;

        if (readyTimer <= 0)
        {
            ReadyTimerEnd?.Invoke();
            readyTimerStop = true;
        }

        if (readyTimer > 0)
        {
            readyTimer -= Time.deltaTime;
        }
    }
}
