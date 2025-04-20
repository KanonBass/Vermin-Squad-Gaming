using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSceneManager : MonoBehaviour
{
    /// <summary>
    /// Change the scene using a scene name
    /// </summary>
    /// <param name="sceneName"></param>
    //This changes the scene. Just attach this to an object that you should call "Scene Manager"
    //Then you can call this function in an event to change the scene by giving it the name of the scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Change the scene using a scene from the asset list
    /// </summary>
    /// <param name="scene"></param>
    //This allows you to change the scene by calling this function in an event, then dragging in a scene from the assets list
    public void ChangeScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }
}
