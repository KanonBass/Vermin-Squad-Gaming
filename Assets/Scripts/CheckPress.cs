using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

//This script is meant to check a collection of inputs for you to use through an event
//All you need to do is put this in an object in the scene. Then add a script and a function to the related even
public class CheckPress: MonoBehaviour
{

    //this stores a type of input defined within the unity editor
    //You can add more types of input in the edit>Project Settings>Input System Package
    //Then create a new variable and assign a function in the start section to the started, canceled, and performed fariables of the action
    private InputAction action;

    //these are the events that are invoked when an action is performed. You can add a function to the event in the unity editor
    //the angled brackets are used for return values. When the function is invoked you must provide a boolean field to the function
    public UnityEvent<bool> Press;
    public UnityEvent<bool> Release;


    void Start()
    {
        //This finds the action that I am wanting to watch for
        //"Book Reading" is an action defined in the project settings
        action = InputSystem.actions.FindAction("Book Reading");

        //These add functions to the started and canceled states of the action
        action.started += Pressed;
        action.canceled += Released;
    }

    //this funciton is just used to invoke the the event when the action is called
    //the field required to call the function is just something the input requires. If you make a new function for the input just put the inputaction thing in there
    private void Pressed(InputAction.CallbackContext obj)
    {
        Press.Invoke(true);
    }

    private void Released(InputAction.CallbackContext obj)
    {
        Release.Invoke(false);
    }
}
