using UnityEngine;
using UnityEngine.Localization.Settings;


public class SpeechMenu : EndMenu
{
    public void ChangeMainText(bool isWin)
    {
        if (LocalizationSettings.SelectedLocale.LocaleName == "English")
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
        else
        {
            if (isWin)
            {
                primaryText.text = "Gewonnen!";
            }
            else
            {
                primaryText.text = "Verloren!";
            }
        }
            
    }

    public void ChangeSecondText(string time)
    {
        secondaryText.text = time;
    }
}
