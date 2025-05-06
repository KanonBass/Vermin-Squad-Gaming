using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class PatientSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject leftSpawn;
    [SerializeField] private GameObject rightSpawn;
    [SerializeField] private GameObject leftPoint;

    [SerializeField] private float xPatientDistance = 1.25f;

    [SerializeField] private Patient[] patientTypes;

    [SerializeField] private float defaultMaxTime = 10;
    [SerializeField] private float maxTimeSpeedMultiplier = 1;
    [SerializeField] private float baseVelocity = 5;
    [SerializeField] private float velocitySpeedMultiplier = 1;
    [SerializeField] private float baseAcceleration;
    [SerializeField] private float accelerationSpeedMultiplier = 1;


    private GameObject nextSpawn;

    private int patientNumber = 0;

    private GameObject currentPatients;

    public UnityEvent<Patient> PatientSpawned;
    public UnityEvent<GameObject> NewPatient;
    public UnityEvent UpdateSpeed;

    private bool isEnabled = true;

    private float currentSpeed;

    private void Start()
    {
        SpawnPatient(0);
        SpawnPatient(1);
        SpawnPatient(2);
    }

    public Patient SpawnPatient(int newDestination)
    {
        Patient newPatient = new Patient();

        newPatient.destinationPoint = new Vector3(leftPoint.transform.position.x + xPatientDistance * newDestination, leftPoint.transform.position.y, leftPoint.transform.position.z);
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

        int spawnNumber = UnityEngine.Random.Range(0, patientTypes.Length);
        newPatient.illness = patientTypes[spawnNumber].illness;
        newPatient.maxTime = defaultMaxTime - (currentSpeed * maxTimeSpeedMultiplier);
        newPatient.velocity = baseVelocity + (currentSpeed * velocitySpeedMultiplier);
        newPatient.acceleration = baseAcceleration + (currentSpeed * accelerationSpeedMultiplier);

        newPatient.model = Instantiate(patientTypes[spawnNumber].model, nextSpawn.transform.position, Quaternion.identity);
        AddSpawnListener(newPatient.model);
        PatientSpawned?.Invoke(newPatient);
        RemoveSpawnListener(newPatient.model);
        NewPatient?.Invoke(newPatient.model);

        patientNumber++;

        return newPatient;
    }

    public void AddSpawnListener(GameObject newObject)
    {
        PatientSpawned.AddListener(newObject.GetComponent<PatientAI>().SetPatient);
    }

    public void RemoveSpawnListener(GameObject removingObject)
    {
        PatientSpawned.RemoveListener(removingObject.GetComponent<PatientAI>().SetPatient);
    }

    public void PatientReturned(Patient returnedPatient)
    {
        if (isEnabled)
        {
            UpdateSpeed.Invoke();

            if (returnedPatient.destinationPoint.x == leftPoint.transform.position.x)
            {
                SpawnPatient(0);
            }
            else if (returnedPatient.destinationPoint.x == leftPoint.transform.position.x + xPatientDistance)
            {
                SpawnPatient(1);
            }
            else
            {
                SpawnPatient(2);
            }
        }
    }

    public void ChangeEnabled(bool newVal)
    {
        isEnabled = newVal;
    }

    public void ChangeSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
}

