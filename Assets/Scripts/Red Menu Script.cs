using UnityEditor;
using UnityEngine;

public class RedMenuScript : EndMenu
{
    public void UpdateTime(float time)
    {
        secondaryText.text = "Time Taken: " + Mathf.Round(time * 10.0f) * 0.1f + "s";
    }

    public void UpdateMainText(bool didWin)
    {
        if (didWin)
        {
            primaryText.text = "You Win!";
        }
        else
        {
            primaryText.text = "Caught!";
        }
    }
}
