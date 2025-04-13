using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LightScoreScript : ScoreTracker
{
    public static bool reading = false;
    public UnityEvent<float> scoreUpdate;
    public UnityEvent gameWon;

    private void Update()
    {
        if (reading)
        {
            UpdateScore(Time.deltaTime);
        }
        else
        {
            UpdateScore(-Time.deltaTime);
        }

        scoreUpdate?.Invoke(GetScore()/GetMaxScore());

        if (GetScore() >= GetMaxScore())
        {
            gameWon.Invoke();
        }
    }

    public void ChangeReadingState(bool state)
    {
        reading = state;
    }
}
