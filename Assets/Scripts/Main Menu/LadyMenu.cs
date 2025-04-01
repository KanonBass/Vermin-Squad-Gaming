using UnityEngine;
using UnityEngine.SceneManagement;

public class LadyMenu : MonoBehaviour
{
    [SerializeField] private string ladyGameName1 = null;
    [SerializeField] private string ladyGameName2 = null;
    [SerializeField] private string ladyGameName3 = null;

    public void ladyGame1Select()
    {
        if (ladyGameName1 != null && SceneUtility.GetBuildIndexByScenePath(ladyGameName1) != -1)
        {
            SceneManager.LoadScene(ladyGameName1);
        }
        else
        {
            Debug.Log("lady Game 1 not defined properly or set within scene list. You can define the scene in the lady Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }

    }

    public void ladyGame2Select()
    {
        if (ladyGameName2 != null && SceneUtility.GetBuildIndexByScenePath(ladyGameName2) != -1)
        {
            SceneManager.LoadScene(ladyGameName2);
        }
        else
        {
            Debug.Log("lady Game 1 not defined properly or set within scene list. You can define the scene in the lady Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }
    }

    public void ladyGame3Select()
    {
        if (ladyGameName3 != null && SceneUtility.GetBuildIndexByScenePath(ladyGameName3) != -1)
        {
            SceneManager.LoadScene(ladyGameName3);
        }
        else
        {
            Debug.Log("lady Game 1 not defined properly or set within scene list. You can define the scene in the lady Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }
    }
}
