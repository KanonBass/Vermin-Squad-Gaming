using UnityEngine;

public class MedicineScript : MonoBehaviour
{
    private bool pressState;
    private bool hasReleased = false;
    private CapsuleCollider thisCollider;
    private Rigidbody thisBody;

    private Camera cam;

    private Ray ray;
    private RaycastHit hit;



    private void Awake()
    {
        thisCollider = GetComponent<CapsuleCollider>();
        thisBody = GetComponent<Rigidbody>();
        thisCollider.enabled = false;
        thisBody.isKinematic = true;
    }

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pressState = true;
    }

    void Update()
    {
        if (pressState && !hasReleased)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            

            transform.position = hit.point;
        }
        else
        {
            thisCollider.enabled = true;
            thisBody.isKinematic = false;
            GetComponent<ThrowScript>().ThrowMedicine(false);
        }
    }

    public void ChangePressState(bool newState)
    {
        pressState = newState;
        hasReleased = true;
    }
}
