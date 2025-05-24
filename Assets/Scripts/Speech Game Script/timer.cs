using NUnit.Framework;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Events;
public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; 
    [SerializeField] float RemainingTime;
    private float initialTime;
    

    public UnityEvent TimeOut;
    public UnityEvent<string> ChangeTime;

    int minutes;
    int seconds;

    private void Start()
    {
        initialTime = RemainingTime;
    }

    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= 1*Time.deltaTime; 
        }
        else if (RemainingTime < 0)
        {
            RemainingTime = 0;
            TimeOut.Invoke();
            timerText.color = Color.red;
            

        }
            
        minutes = Mathf.FloorToInt(RemainingTime / 60); 
        seconds = Mathf.FloorToInt(RemainingTime % 60);
        timerText.text = "Time " + string.Format("{0:00}:{1:00}", minutes, seconds); // RemainingTime = time assigned in Unity in Countdown text. This divides the given time by 60 for minutes and 60 with a % to display the remaining number. Example: 5%2 = 1.
    }

    public void UpdateTime()
    {
        var thisMin = Mathf.FloorToInt((initialTime - RemainingTime) / 60);
        var thisSec = Mathf.FloorToInt((initialTime - RemainingTime) % 60);

        ChangeTime.Invoke("Time Taken: " + string.Format("{0:00}:{1:00}", thisMin, thisSec));
    }
}
