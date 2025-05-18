using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Track the score of the medicine game
/// </summary>
public class MedicineScoreSciprt : ScoreTracker
{
    /// <summary>
    /// How much the score increases at the start of the game
    /// </summary>
    [SerializeField] private float baseScoreIncrease = 1;
    /// <summary>
    /// How quickly the score scales with the speed of the game
    /// </summary>
    [SerializeField] private float speedMultiplier = .5f;

    //Current speed of the game
    private float currentSpeed;

    /// <summary>
    /// Tell other objects the score
    /// </summary>
    public UnityEvent<string> NewScore;

    //Tell the game the start score
    private void Start()
    {
        NewScore?.Invoke("Score: " + (int)GetScore());
    }

    //Update the score based on the base score and the speed
    public void MedicineScoreUpdate()
    {
        UpdateScore(baseScoreIncrease + (currentSpeed * speedMultiplier));
        NewScore?.Invoke("Score: " + (int)GetScore());
    }

    /// <summary>
    /// Update the speed of the game
    /// </summary>
    /// <param name="newSpeed"></param>
    public void ChangeSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
}
