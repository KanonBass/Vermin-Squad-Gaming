using UnityEngine;
using UnityEngine.Events;

public class MedicineBoxScript : MonoBehaviour
{
    /// <summary>
    /// The prefab that the medicine box should spawn
    /// </summary>
    [SerializeField] private GameObject medicine;
    /// <summary>
    /// The main camera
    /// </summary>
    [SerializeField] private Camera cam;

    /// <summary>
    /// Stores the medicine object that is spawned
    /// </summary>
    private GameObject newMedicine;

    /// <summary>
    /// Invoked when a new medicine is spawned
    /// </summary>
    public UnityEvent<GameObject> MedicineCreated;

    /// <summary>
    /// Stores if the button is pressed
    /// </summary>
    private bool pressState = false;

    //These are used to store the location the player clicks to spawn the object
    private Ray ray;
    private RaycastHit hit;


    /// <summary>
    /// Change the press state of the medicine box
    /// </summary>
    /// <param name="newState"></param>
    public void changeState(bool newState)
    {
        pressState = newState;
    }

    /// <summary>
    /// Detects when the player clicks on the object in the scene
    /// </summary>
    private void OnMouseDown()
    {
        ////These are all used to calculate the spawn position of the medicine
        ////First you create a ray from the camera based on the mouse's position 
        //ray = cam.ScreenPointToRay(Input.mousePosition);
        ////Then you cast the ray, which will return a RaycastHit based on the first thing the ray collides with
        //Physics.Raycast(ray, out hit);
        ////then we set the medicine's transform position to the point
        //medicine.transform.position = hit.point;

        ////Once we know where it spawns we instantiate the object at that position, which is stored in newMedicine
        //newMedicine = Instantiate(medicine, medicine.transform);
        ////Finally we invoke this event to tell other scripts that a new medicine has been created
        //MedicineCreated?.Invoke(newMedicine);
    }
}
