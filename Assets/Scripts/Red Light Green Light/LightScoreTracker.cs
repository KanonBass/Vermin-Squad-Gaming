using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Score tracker meant specifically for the red light minigame, inherits from the ScoreTracker script
/// </summary>
public class LightScoreScript : ScoreTracker
{
    public GameObject Book;
    public GameObject OpenBook;
    public GameObject Bookparticles;
    //Used to keep track of when the button is pressed, meaning the player is reading
    private static bool reading = false;

    /// <summary>
    /// Multiplier for when the player is gaining points
    /// </summary>
    [SerializeField] private float gainPointMult = 1f;

    /// <summary>
    /// Multiplier for when the player is losing points
    /// </summary>
    [SerializeField] private float losePointMult = 1f;

    /// <summary>
    /// Triggers every time the score is updated, currently returns the percentage of the score with the max score
    /// </summary>
    //scoreUpdate is an event that is used called when the score is updated to change things like the score bar
    public UnityEvent<float> scoreUpdate;

    /// <summary>
    /// Triggers when you have reached the maximum score, winning the game
    /// </summary>
    //Triggers when you win the game at max score
    public UnityEvent gameWon;

    private void Update()
    {
        //this if block checks whether the player is currently reading (by clicking) and updates the score
        if (reading)
        {
            UpdateScore(Time.deltaTime*gainPointMult);
            Book.SetActive(false);
            OpenBook.SetActive(true);
            Bookparticles.SetActive(true);
        }
        else if(GetScore() > GetMinScore()) 
        {
            UpdateScore(-Time.deltaTime*losePointMult);
            Book.SetActive(true);
            OpenBook.SetActive(false);
            Bookparticles.SetActive(false);
        }

        //This is called every frame to send out the current proportion of the score to the score bar, which is then filled based on this proportion
        scoreUpdate?.Invoke(GetScore()/GetMaxScore());

        //Checks if the score is at max. If it is then the player wins
        if (GetScore() >= GetMaxScore())
        {
            gameWon.Invoke();
        }
    }

    /// <summary>
    /// Update if the player is currently reading
    /// </summary>
    /// <param name="state"></param>
    //This is used in the inputscript's event to change the state based on if the button is pressed or not
    public void ChangeReadingState(bool state)
    {
        reading = state;
    }
}
