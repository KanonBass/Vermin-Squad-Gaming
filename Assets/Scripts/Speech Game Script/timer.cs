using NUnit.Framework;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float RemainingTime;
    public GameObject GamePanel;
    public GameObject LosePanel;

    private void Start()
    {
        LosePanel.SetActive(false);
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
            LosePanel.SetActive(true);
            GamePanel.SetActive(false);
            timerText.color = Color.red;
            

        }
            
        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
