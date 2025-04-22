using UnityEngine;

public class NewMedScript : MonoBehaviour
{
    [SerializeField] private GameObject medicinePrefab;

    private Vector3 startPosition;

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

    private bool isSelected = false;

    /// <summary>
    /// The main Camera
    /// </summary>
    private Camera cam;

    //Ray information used to track the player's mouse
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private float xThrowMult;
    [SerializeField] private float yThrowMult;
    [SerializeField] private float zThrowMult;

    private void Awake()
    {
        //Gets the collider and rigid body of this object
        thisBody = GetComponent<Rigidbody>();

        
        //We set kinematic to false to disable the rigid body and prevent the medicine from being affected by gravity
        thisBody.isKinematic = true;
    }

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        startPosition = transform.position;

        thisCollider = GetComponent<CapsuleCollider>();
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    /// <summary>
    /// This is used to change the released variable of the medicine
    /// </summary>
    /// <param name="newState"></param>
    public void ChangePressState(bool newState)
    {        
        if (isSelected && !hasReleased)
        {
            Debug.Log("Should be thrown");

            hasReleased = true;

            thisBody.isKinematic = false;

            ThrowMeds();
        }
    }

    public void ThrowMeds()
    {
        Debug.Log("Should be Thrown");

        thisCollider.enabled = false;

        ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        float xForce;
        float zForce;

        xForce = hit.point.x - transform.position.x;
        zForce = hit.point.z - transform.position.z;

        Vector3 force = new Vector3(xForce * xThrowMult, yThrowMult, zForce * zThrowMult);


        thisCollider.enabled = true;
        GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
    }


}
