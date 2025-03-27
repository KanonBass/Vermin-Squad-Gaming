using UnityEngine;
using UnityEngine.SceneManagement;

public class FeministMenu : MonoBehaviour
{
    [SerializeField] private string feministGameName1 = null;
    [SerializeField] private string feministGameName2 = null;
    [SerializeField] private string feministGameName3 = null;

    public void feministGame1Select()
    {
        if (feministGameName1 != null && SceneUtility.GetBuildIndexByScenePath(feministGameName1) != -1)
        {
            SceneManager.LoadScene(feministGameName1);
        }
        else
        {
            Debug.Log("feminist Game 1 not defined properly or set within scene list. You can define the scene in the feminist Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }

    }

    public void feministGame2Select()
    {
        if (feministGameName2 != null && SceneUtility.GetBuildIndexByScenePath(feministGameName2) != -1)
        {
            SceneManager.LoadScene(feministGameName2);
        }
        else
        {
            Debug.Log("feminist Game 1 not defined properly or set within scene list. You can define the scene in the feminist Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }
    }

    public void feministGame3Select()
    {
        if (feministGameName3 != null && SceneUtility.GetBuildIndexByScenePath(feministGameName3) != -1)
        {
            SceneManager.LoadScene(feministGameName3);
        }
        else
        {
            Debug.Log("feminist Game 1 not defined properly or set within scene list. You can define the scene in the feminist Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }
    }
}
