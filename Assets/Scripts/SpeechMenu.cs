using UnityEngine;

public class SpeechMenu : EndMenu
{
    public void ChangeMainText(bool isWin)
    {
        if (isWin)
        {
            primaryText.text = "You Win!";
        }
        else
        {
            primaryText.text = "You Lose!";
        }
    }

    public void ChangeSecondText(string time)
    {
        secondaryText.text = "Time Remaining: " + time;
    }
}
