using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class PatientSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject leftSpawn;
    [SerializeField] private GameObject rightSpawn;
    [SerializeField] private GameObject leftPoint;

    [SerializeField] private float xPatientDistance;

    [SerializeField] private Patient[] patientTypes;


    private GameObject nextSpawn;

    private int patientNumber = 0;

    private GameObject currentPatients;

    public UnityEvent<Patient> PatientSpawned;

    private void Start()
    {
        SpawnPatient(0);
        SpawnPatient(1);
        SpawnPatient(2);
    }

    public Patient SpawnPatient(int newDestination)
    {
        Patient newPatient = patientTypes[UnityEngine.Random.Range(0, patientTypes.Length - 1)];

        Vector3 destination = new Vector3(leftPoint.transform.position.x + 1 * xPatientDistance * newDestination, leftPoint.transform.position.y, leftPoint.transform.position.z);
        newPatient.destinationPoint = destination;
        newPatient.patientNum = newDestination;
        

        if (patientNumber%2 == 0)
        {
            nextSpawn = leftSpawn;
            newPatient.returnPoint = leftSpawn;
        }
        else
        {
            nextSpawn = rightSpawn;
            newPatient.returnPoint = rightSpawn;
        }

        Instantiate(newPatient.model, nextSpawn.transform.position, Quaternion.identity);
        AddSpawnListener(newPatient.model);
        PatientSpawned?.Invoke(newPatient);

        return newPatient;
    }

    public void AddSpawnListener(GameObject newObject)
    {
        PatientSpawned.AddListener(newObject.GetComponent<PatientInfo>().SetPatient);
    }

    public void RemoveSpawnListener(GameObject removingObject)
    {
        PatientSpawned.RemoveListener(removingObject.GetComponent<PatientInfo>().SetPatient);
    }
}
