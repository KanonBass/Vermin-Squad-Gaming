using Unity.VisualScripting;
using UnityEngine;

public class NewMedScript : MonoBehaviour
{
    [SerializeField] private GameObject medicinePrefab;
    [SerializeField] private string illnessCured;

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

    [SerializeField] private float maxLifetime = 5;
    private float currentLifetime = 0;

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
    /// This is used to change the released variable of the medicine
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

    public void ThrowMeds()
    {
        thisCollider.enabled = false;

        ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        float xForce;
        float zForce;


        xForce = hit.point.x - transform.position.x;
        zForce = hit.point.z - transform.position.z;
     

        Vector3 force = new Vector3(xForce * xThrowMult, yThrowMult, zForce * zThrowMult);
        Vector3 tumble = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));

        thisCollider.enabled = true;
        GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddTorque(tumble);
    }

    public string getIllness()
    {
        return illnessCured;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Patient"))
        {
            hasHit = true;
            thisCollider.enabled = false;
        }
    }
}
