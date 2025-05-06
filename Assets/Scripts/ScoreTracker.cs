using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Should be attatched to an object that will keep track of the score
/// </summary>
public class ScoreTracker : MonoBehaviour
{
    //serialized fields to allow easy editing of key features without the need to edit the script
    [SerializeField] private float startScore = 0;
    [SerializeField] private float maxScore = 100;
    [SerializeField] private float minScore = 0;

    //Other objects should not be allowed to directly edit the current score and should thus be private
    private float score;
   

    //Sets the score when the scene is loaded
    void Awake()
    {
        score = startScore;
    }

    /// <summary>
    /// Alter the current score, positives will add to the score and negatives will subtract
    /// </summary>
    /// <param name="scoreIncrease"></param>
    public void UpdateScore(float scoreIncrease)
    {
        score += scoreIncrease;
    }
    
    /// <summary>
    /// Return the current score
    /// </summary>
    /// <returns></returns>
    public float GetScore()
    {
        return score;
    }

    /// <summary>
    /// Directly set the score to a specific value, does not add or subtract
    /// </summary>
    /// <param name="newScore"></param>
    public void SetScore(float newScore)
    {
        score = newScore;
    }

    /// <summary>
    /// Return the maximum score you can have
    /// </summary>
    /// <returns></returns>
    //Could be useful to get proportions of the score for something like a score bar or to check when a player wins
    public float GetMaxScore()
    {
        return maxScore;
    }

    /// <summary>
    /// Return the minimum score you can have
    /// </summary>
    /// <returns></returns>
    //Useful for detecting if a player loses or something similar
    public float GetMinScore()
    {
        return minScore;
    }
}
