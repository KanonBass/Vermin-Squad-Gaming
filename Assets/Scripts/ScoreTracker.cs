using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private float startScore = 0;
    private float score;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = startScore;
    }

    public void UpdateScore(float scoreIncrease)
    {
        score += scoreIncrease;
    }

    public float GetScore()
    {
        return score;
    }

    public void SetScore(float newScore)
    {
        score = newScore;
    }
}
