using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Timer script meant specifically for the red light minigame
/// </summary>
public class LightTimerScript : MonoBehaviour
{
    
    private float currentTime = 0;
    private float maxTime;

    /// <summary>
    /// The maximum amount of time the teacher won't look at the player
    /// </summary>
    [SerializeField] private float greenTimerMax = 5;
    /// <summary>
    /// The minimum amount of time the teacher won't look at the player
    /// </summary>
    [SerializeField] private float greenTimerMin = 2;
    /// <summary>
    /// The maximum amount of time the teacher will look at the player
    /// </summary>
    [SerializeField] private float redTimerMax = 1;
    /// <summary>
    /// The minimum amount of time the teacher will look at the player
    /// </summary>
    [SerializeField] private float redTimerMin = 3;
    /// <summary>
    /// How long does the player have to stop reading before they're caught
    /// </summary>
    [SerializeField] private float gracePeriod = .5f;

    
    /// <summary>
    /// Is the teacher looking at the player
    /// </summary>
    private bool isRed = true;

    /// <summary>
    /// Invoked when the teacher switches between looking at the player or not looking
    /// </summary>
    public UnityEvent<bool> StateChange;
    /// <summary>
    /// Invoked when the grace period ends
    /// </summary>
    public UnityEvent GracePeriodEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if the teacher starts as red or green then you generate the respective maxTime
        if (isRed)
        {
            RandomRedTimer(redTimerMax, redTimerMin);
        }
        else
        {
            RandomGreenTimer(greenTimerMax, greenTimerMin);
        }
    }

    
    void Update()
    {
        //Checks if the timer has reached its maximum
        //if it hasn't then we want to increase the timer
        //else then we want to switch between the states and generate a new maxtime for that state
        if (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;

            //if the teacher is looking at the player and the currentTime is more than the gracePeriod then the player is able to be caught
            if (currentTime > gracePeriod && isRed)
            {
                GracePeriodEnd.Invoke();
            }
        }
        else
        {
            //switch between the red or green state
            isRed = !isRed;

            //reset the timer
            currentTime = 0;
            //generate a new maxTime
            maxTime = RandomRedTimer(redTimerMax, redTimerMin) * System.Convert.ToSingle(isRed) + RandomGreenTimer(greenTimerMax, greenTimerMin) * System.Convert.ToSingle(!isRed);
            //tell other scripts the state has changed
            StateChange?.Invoke(isRed);            
        }
    }

    /// <summary>
    /// generates a random maxTime for the green state
    /// </summary>
    /// <param name="thisMax"></param>
    /// <param name="thisMin"></param>
    /// <returns></returns>
    public float RandomGreenTimer(float thisMax, float thisMin)
    {
        float thisTimer = UnityEngine.Random.Range(thisMin, thisMax);

        return thisTimer;
    }

    /// <summary>
    /// generates a random maxTime for the red state
    /// </summary>
    /// <param name="thisMax"></param>
    /// <param name="thisMin"></param>
    /// <returns></returns>
    public float RandomRedTimer(float thisMax, float thisMin)
    {
        float thisTimer = UnityEngine.Random.Range(thisMin, thisMax);

        return thisTimer;
    }
}

