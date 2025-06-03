using Unity.VisualScripting;
using UnityEngine;

public class NewMedScript : MonoBehaviour
{
    /// <summary>
    /// The model of the medicine
    /// </summary>
    [SerializeField] private GameObject medicinePrefab;
    /// <summary>
    /// The illness this medicine cures
    /// </summary>
    [SerializeField] private string illnessCured;

    /// <summary>
    /// The initial position of the medicine, used for vector math
    /// </summary>
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

    /// <summary>
    /// Tracks when the medicine is active + throwable
    /// </summary>
    private bool isSelected;

    
    /// <summary>
    /// The main Camera
    /// </summary>
    private Camera cam;

    //Ray information used to track the player's mouse
    private Ray ray;
    private RaycastHit hit;

    //How hard the medicine is thrown along the different axes
    [SerializeField] private float xThrowMult;
    [SerializeField] private float yThrowMult;
    [SerializeField] private float zThrowMult;

    /// <summary>
    /// How long until the medicine is despawned
    /// </summary>
    [SerializeField] private float maxLifetime = 5;
    private float currentLifetime = 0;

    /// <summary>
    /// How long the medicine is alive after it hits a patient
    /// </summary>
    [SerializeField] private float maxHitLifetime = .5f;
    private float hitLifetime = 0;
    private bool hasHit = false;

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

        isSelected = true;

        thisCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        //If the player has thrown the medicine then this tracks when it should despawn
        if (hasReleased)
        {
            currentLifetime += Time.deltaTime;
            if (currentLifetime > maxLifetime)
            {
                Destroy(gameObject);
            }

            if (hasHit)
            {
                hitLifetime += Time.deltaTime;
                if(hitLifetime >= maxHitLifetime)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    /// <summary>
    /// Used to change the released variable of the medicine and throw it
    /// </summary>
    /// <param name="newState"></param>
    public void ChangePressState(bool newState)
    {        
        if (isSelected && !hasReleased)
        {
            hasReleased = true;

            thisBody.isKinematic = false;

            ThrowMeds();
        }
    }

    /// <summary>
    /// Throws the medicine towards the mouse's position
    /// </summary>
    public void ThrowMeds()
    {
        //The collider is temporarily disabled to prevent issues with the ray being cast
        thisCollider.enabled = false;

        //Cast a ray from the mouse's position.
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        float xForce;
        float zForce;

        //Simple vector math to get the direction from the medicine to where the ray hit on the x-z plane
        xForce = hit.point.x - transform.position.x;
        zForce = hit.point.z - transform.position.z;
     

        //Vector for the throw force in the correct direction with some vertical force as well
        Vector3 force = new Vector3(xForce * xThrowMult, yThrowMult, zForce * zThrowMult);
        Vector3 tumble = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));

        thisCollider.enabled = true;

        //Add the force to the rigid body
        GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddTorque(tumble);
    }

    /// <summary>
    /// Retrieve the illness this medicine cures
    /// </summary>
    /// <returns></returns>
    public string getIllness()
    {
        return illnessCured;
    }

    /// <summary>
    /// Prevent the medicine from being able to hit 2 patients
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pre Change Medicine: " + hasHit);
        if (collision.gameObject.CompareTag("Patient") && !hasHit)
        {
            hasHit = true;
            thisCollider.enabled = false;
            Debug.Log("Medicine Has Hit: " + hasHit);
        }
    }

    public bool GetHit()
    {
        Debug.Log("Returning Has Hit" + hasHit);
        return hasHit;
    }
}
