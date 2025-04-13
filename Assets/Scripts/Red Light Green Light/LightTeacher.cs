using UnityEngine;
using UnityEngine.Events;

public class LightTeacher : MonoBehaviour
{
    private bool isRed;
    private bool reading = false;

    public UnityEvent Caught;
    [SerializeField] private Material thisMaterial;

    private Color greenColor;
    private Color redColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ColorUtility.TryParseHtmlString("#33A93D", out greenColor);
        ColorUtility.TryParseHtmlString("#9F0400", out redColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTimeState(bool newState)
    {
        isRed = newState;
    }

    public void ChangeInputState(bool newState)
    {
        reading = newState;
    }

    public void GraceEnd()
    {
        Debug.Log("grace Checked");

        if (reading)
        {
            Caught.Invoke();
            Debug.Log("You Lose");
        }
    }

    public void TeacherColorChange(bool isred)
    {
        Debug.Log("teacher color called");
        Debug.Log("Value is: " + isred);

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
