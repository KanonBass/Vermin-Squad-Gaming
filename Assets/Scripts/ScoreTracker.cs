using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private float startScore = 0;
    [SerializeField] private float maxScore = 100;
    private float score;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
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

    public float GetMaxScore()
    {
        return maxScore;
    }
}
