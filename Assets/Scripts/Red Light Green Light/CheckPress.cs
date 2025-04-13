using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class CheckPress
{
    private InputAction action;

    public UnityEvent<bool> Press;
    public UnityEvent<bool> Release;

    void Start()
    {
        action = InputSystem.actions.FindAction("Book Reading");
        action.started += Pressed;
        action.canceled += Released;
    }

    private void Pressed(InputAction.CallbackContext obj)
    {
        Press.Invoke(true);
    }

    private void Released(InputAction.CallbackContext obj)
    {
        Release.Invoke(false);
    }
}
