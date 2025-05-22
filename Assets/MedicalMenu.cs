using UnityEngine;

public class MedicalMenu : EndMenu
{
    public void UpdateScore(string score)
    {
        secondaryText.text = score;
    }
}
