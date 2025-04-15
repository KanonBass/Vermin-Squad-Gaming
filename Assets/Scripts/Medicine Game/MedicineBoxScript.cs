using UnityEngine;
using UnityEngine.Events;

public class MedicineBoxScript : MonoBehaviour
{
    [SerializeField] private GameObject medicine;
    [SerializeField] private Camera cam;

    private GameObject newMedicine;

    public UnityEvent<GameObject> MedicineCreated;

    private bool pressState = false;

    private Ray ray;
    private RaycastHit hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeState(bool newState)
    {
        pressState = newState;
    }

    private void OnMouseDown()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        medicine.transform.position = hit.point;


        newMedicine = Instantiate(medicine, medicine.transform);
        MedicineCreated?.Invoke(newMedicine);
    }
}
