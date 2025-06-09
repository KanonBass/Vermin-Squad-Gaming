using UnityEditor;
using UnityEngine;

using UnityEngine.Localization.Settings;

public class RedMenuScript : EndMenu
{
    public void UpdateTime(float time)

    {
        if (LocalizationSettings.SelectedLocale.LocaleName == "English") //freyapoop
        {
            secondaryText.text = "Time Taken: " + Mathf.Round(time * 10.0f) * 0.1f + "s";
        }
        else
        {
            secondaryText.text = "Tijd: " + Mathf.Round(time * 10.0f) * 0.1f + "s";
        }
    }

    public void UpdateMainText(bool didWin)
    {

        if (LocalizationSettings.SelectedLocale.LocaleName == "English")

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
        else
        {
            if (didWin)
            {
                primaryText.text = "Gewonnen!";
            }
            else
            {
                primaryText.text = "Betrapt!";
            }
        }
    }
}
