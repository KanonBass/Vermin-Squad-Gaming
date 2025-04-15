using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RedLightInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InputAction action;

    public UnityEvent<bool> Press;
    public UnityEvent<bool> Release;

    private bool pressState = false;


    void Start()
    {
        action = InputSystem.actions.FindAction("Book Reading");
        action.started += Pressed;
        action.canceled += Released;
    }

    private void Pressed(InputAction.CallbackContext obj)
    {
        Press.Invoke(true);
        pressState = true;
    }

    private void Released(InputAction.CallbackContext obj)
    {
        Release.Invoke(false);
        pressState = false;
    }

    public void AddListener(GameObject newObject)
    {
        Press.AddListener(newObject.GetComponent<MedicineScript>().ChangePressState);
        Release.AddListener(newObject.GetComponent<MedicineScript>().ChangePressState);
        
    }
}
