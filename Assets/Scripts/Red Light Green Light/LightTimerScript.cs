using System;
using UnityEngine;
using UnityEngine.Events;

public class LightTimerScript : MonoBehaviour
{
    private float currentTime = 0;
    private float maxTime;

    [SerializeField] private float greenTimerMax = 5;
    [SerializeField] private float greenTimerMin = 2;
    [SerializeField] private float redTimerMax = 1;
    [SerializeField] private float redTimerMin = 3;
    [SerializeField] private float gracePeriod = .5f;

    private bool isRed = true;

    public UnityEvent<bool> StateChange;
    public UnityEvent GracePeriodEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isRed)
        {
            RandomRedTimer(redTimerMax, redTimerMin);
        }
        else
        {
            RandomGreenTimer(greenTimerMax, greenTimerMin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            if (currentTime > gracePeriod && isRed)
            {
                GracePeriodEnd.Invoke();
            }
        }
        else
        {
            isRed = !isRed;
            currentTime = 0;
            maxTime = RandomRedTimer(redTimerMax, redTimerMin) * System.Convert.ToSingle(isRed) + RandomGreenTimer(greenTimerMax, greenTimerMin) * System.Convert.ToSingle(!isRed);
            Debug.Log("isRed changed to: " + isRed + " new time is: " + maxTime);
            StateChange?.Invoke(isRed);
            
        }
    }

    public float RandomGreenTimer(float thisMax, float thisMin)
    {
        float thisTimer = UnityEngine.Random.Range(thisMin, thisMax);

        return thisTimer;
    }

    public float RandomRedTimer(float thisMax, float thisMin)
    {
        float thisTimer = UnityEngine.Random.Range(thisMin, thisMax);

        return thisTimer;
    }
}

