using UnityEngine;
using UnityEngine.Events;

public class MedicineScoreSciprt : ScoreTracker
{
    [SerializeField] private float baseScoreIncrease = 1;
    [SerializeField] private float speedMultiplier = .5f;

    private float currentSpeed;

    public UnityEvent<string> NewScore;

    private void Start()
    {
        NewScore?.Invoke("Score: " + (int)GetScore());
    }

    public void MedicineScoreUpdate()
    {
        UpdateScore(baseScoreIncrease + (currentSpeed * speedMultiplier));
        NewScore?.Invoke("Score: " + (int)GetScore());
    }

    public void ChangeSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
}
