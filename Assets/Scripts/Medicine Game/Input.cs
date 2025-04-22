using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// This script inherits from the CheckPress script, which detects input
/// </summary>
public class RedLightInput : CheckPress
{   
    /// <summary>
    /// Manually add the object as new listeners to the press and release inputs 
    /// </summary>
    /// <param name="newObject"></param>
    public void AddListener(GameObject newObject)
    {
        //this is necessary because prefabs in the scene don't inherit the event relationships of prefabs in the asset list

        //These find the necessary methods of the object
        Press.AddListener(newObject.GetComponent<NewMedScript>().ChangePressState);
        Release.AddListener(newObject.GetComponent<NewMedScript>().ChangePressState);
    }
}
