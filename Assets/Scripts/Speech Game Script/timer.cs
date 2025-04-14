using NUnit.Framework;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float RemainingTime;

    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= 1*Time.deltaTime;
        }
        else if (RemainingTime < 0)
        {
            RemainingTime = 0;
            timerText.color = Color.red;
        }
            
        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
