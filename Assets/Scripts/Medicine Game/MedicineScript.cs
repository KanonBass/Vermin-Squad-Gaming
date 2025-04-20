using UnityEngine;

/// <summary>
/// Script used by the medicine to follow the player's mouse
/// </summary>
public class MedicineScript : MonoBehaviour
{
    /// <summary>
    /// Has the player released input
    /// </summary>
    /// This is used to prevent the pills from tracking the player's mouse again after they've been released
    private bool hasReleased = false;
    /// <summary>
    /// This medicine's collider
    /// </summary>
    private CapsuleCollider thisCollider;
    /// <summary>
    /// This medicine's rigid body
    /// </summary>
    private Rigidbody thisBody;

    /// <summary>
    /// The main Camera
    /// </summary>
    private Camera cam;

    //Ray information used to track the player's mouse
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        //Gets the collider and rigid body of this object
        thisCollider = GetComponent<CapsuleCollider>();
        thisBody = GetComponent<Rigidbody>();

        //We set the collider to false to prevent the ray from hitting the capsule while tracking the mouse
        thisCollider.enabled = false;
        //We set kinematic to false to disable the rigid body and prevent the medicine from being affected by gravity
        thisBody.isKinematic = true;
    }

    private void Start()
    {
        //Here we get the main camera of the scene
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        //If the player hasn't released their input then the medicine should follow their input
        if (!hasReleased)
        {
            //Here we cast a ray to the scene, which should hit either the table or an invisible block near the front of the table.
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            //Then we move the position of this object to the raycast hit point
            transform.position = hit.point;
        }
        else
        {
            //When the button is released we want to reenable the collider to allow the medicine to collide with the people
            thisCollider.enabled = true;
            //We also want to have the medicine be affected by physics when released
            thisBody.isKinematic = false;
            
            GetComponent<ThrowScript>().ThrowMedicine(false);
        }
    }

    /// <summary>
    /// This is used to change the released variable of the medicine
    /// </summary>
    /// <param name="newState"></param>
    public void ChangePressState(bool newState)
    {
        hasReleased = true;
    }
}
