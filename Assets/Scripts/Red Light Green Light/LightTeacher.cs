using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Script for the teacher in the red light minigame
/// </summary>
public class LightTeacher : MonoBehaviour
{
    /// <summary>
    /// Is the teacher looking at the player
    /// </summary>
    private bool isRed;

    /// <summary>
    /// Is the player currently reading
    /// </summary>
    private bool reading = false;

    /// <summary>
    /// Invoked if the player is caught by the teacher
    /// </summary>
    public UnityEvent Caught;

    //The material of the teacher which is used to change color, temporary for now
    [SerializeField] private Material thisMaterial;

    //colors used for the states of the teacher, temporary
    private Color greenColor;
    private Color redColor;


    void Start()
    {
        //define the colors of the teacher using hexadecimal 
        ColorUtility.TryParseHtmlString("#33A93D", out greenColor);
        ColorUtility.TryParseHtmlString("#9F0400", out redColor);
    }

    /// <summary>
    /// Change if the teacher is currently looking at the player
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeTimeState(bool newState)
    {
        isRed = newState;
    }

    /// <summary>
    /// Change if the player is currently reading using mouse or touch
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeInputState(bool newState)
    {
        reading = newState;
    }

    /// <summary>
    /// Call when the grace period has ended to chack if the player is reading
    /// </summary>
    public void GraceEnd()
    {
        Debug.Log("grace Checked");

        if (reading)
        {
            Caught.Invoke();
            Debug.Log("You Lose");
        }
    }

    /// <summary>
    /// Change the color of the teacher, temporary
    /// </summary>
    /// <param name="isred"></param>
    public void TeacherColorChange(bool isred)
    {
        if (isred)
        {
            Debug.Log("material should be red");
            this.GetComponent<Renderer>().material.color = redColor;
        }
        else
        {
            Debug.Log("material should be green");
            this.GetComponent<Renderer>().material.color = greenColor;
        }
    }
}
