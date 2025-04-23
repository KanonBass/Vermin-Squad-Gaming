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
        Debug.Log(newDestination);
        Patient newPatient = new Patient();

        newPatient.destinationPoint = new Vector3(leftPoint.transform.position.x + 1 * xPatientDistance * newDestination, leftPoint.transform.position.y, leftPoint.transform.position.z);
        newPatient.patientNum = newDestination;

        Debug.Log(newPatient.patientNum);
        

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

        newPatient.model = Instantiate(patientTypes[UnityEngine.Random.Range(0, patientTypes.Length)].model, nextSpawn.transform.position, Quaternion.identity);
        AddSpawnListener(newPatient.model);
        Debug.Log( newPatient.patientNum);
        PatientSpawned?.Invoke(newPatient);
        RemoveSpawnListener(newPatient.model);

        patientNumber++;

        return newPatient;
    }

    public void AddSpawnListener(GameObject newObject)
    {
        Debug.Log("Patient is added to listener");
        PatientSpawned.AddListener(newObject.GetComponent<PatientAI>().SetPatient);
    }

    public void RemoveSpawnListener(GameObject removingObject)
    {
        PatientSpawned.RemoveListener(removingObject.GetComponent<PatientAI>().SetPatient);
    }
}
