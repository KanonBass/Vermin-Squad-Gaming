using UnityEngine;
using UnityEngine.InputSystem;

public class AlettaPoetryScript : MonoBehaviour
{
    private InputAction action;

    void Start()
    {
        action = InputSystem.actions.FindAction("Book Reading");
        action.started += pressed;
        action.canceled += released;
    }

    void Update()
    {
        
    }

    private void pressed(InputAction.CallbackContext obj)
    {

    }

    private void released(InputAction.CallbackContext obj)
    {
        
    }
}
