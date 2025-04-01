using UnityEngine;
using UnityEngine.SceneManagement;

public class MedicalMenu : MonoBehaviour
{
    [SerializeField] private string medicalGameName1 = null;
    [SerializeField] private string medicalGameName2 = null;
    [SerializeField] private string medicalGameName3 = null;

    public void medicalGame1Select()
    {
        if (medicalGameName1 != null && SceneUtility.GetBuildIndexByScenePath(medicalGameName1) != -1)
        {
            SceneManager.LoadScene(medicalGameName1);
        }
        else
        {
            Debug.Log("medical Game 1 not defined properly or set within scene list. You can define the scene in the medical Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }

    }

    public void medicalGame2Select()
    {
        if (medicalGameName2 != null && SceneUtility.GetBuildIndexByScenePath(medicalGameName2) != -1)
        {
            SceneManager.LoadScene(medicalGameName2);
        }
        else
        {
            Debug.Log("medical Game 1 not defined properly or set within scene list. You can define the scene in the medical Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }
    }

    public void medicalGame3Select()
    {
        if (medicalGameName3 != null && SceneUtility.GetBuildIndexByScenePath(medicalGameName3) != -1)
        {
            SceneManager.LoadScene(medicalGameName3);
        }
        else
        {
            Debug.Log("medical Game 1 not defined properly or set within scene list. You can define the scene in the medical Game Select Menu Group. You can set the scene in the scene list by going to file>Build Profiles>Scene List");
        }
    }
}
