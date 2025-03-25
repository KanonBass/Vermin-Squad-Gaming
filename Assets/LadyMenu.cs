using UnityEngine;
using UnityEngine.SceneManagement;

public class LadyMenu : MonoBehaviour
{
    public void LadyGame1Select()
    {
        SceneManager.LoadScene("Lady Game 1");
    }

    public void LadyGame2Select()
    {
        SceneManager.LoadScene("Lady Game 2");
    }

    public void LadyGame3Select()
    {
        SceneManager.LoadScene("Lady Game 3");
    }
}
