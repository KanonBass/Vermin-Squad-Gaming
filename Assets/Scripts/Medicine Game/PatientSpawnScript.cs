using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Used to spawn patients for the medical minigame
/// </summary>
public class PatientSpawnScript : MonoBehaviour
{
    /// <summary>
    /// Point where patients spawn to the left of the building
    /// </summary>
    [SerializeField] private GameObject leftSpawn;
    /// <summary>
    /// Point where patients spawn to the right of the building
    /// </summary>
    [SerializeField] private GameObject rightSpawn;
    /// <summary>
    /// The left most position where a patient will stand in front of the desk
    /// </summary>
    [SerializeField] private GameObject leftPoint;

    /// <summary>
    /// The stopping distance of the patient
    /// </summary>
    [SerializeField] private float xPatientDistance = 1.25f;

    /// <summary>
    /// All of the different types of patients that are randomly spawned
    /// </summary>
    [SerializeField] private Patient[] patientTypes;

    /// <summary>
    /// The inital maximum amount of time a patient will wait for medicine
    /// </summary>
    [SerializeField] private float defaultMaxTime = 10;
    /// <summary>
    /// How quickly the max time will scale down
    /// </summary>
    [SerializeField] private float maxTimeSpeedMultiplier = 1;
    /// <summary>
    /// The base maximum velocity of a patient
    /// </summary>
    [SerializeField] private float baseVelocity = 5;
    /// <summary>
    /// How quickly the maximum velocity of the patient scales
    /// </summary>
    [SerializeField] private float velocitySpeedMultiplier = 1;

    /// <summary>
    /// Tracks which point the next patient should spawn at
    /// </summary>
    private GameObject nextSpawn;

    /// <summary>
    /// Keeps track of the number of patients spawned
    /// </summary>
    private int patientNumber = 0;

    /// <summary>
    /// Used to transfer all necessary information from this script to a patient
    /// </summary>
    public UnityEvent<Patient> PatientSpawned;
    /// <summary>
    /// Used to add a patient as a listener to other object's events
    /// </summary>
    public UnityEvent<GameObject> NewPatient;
    /// <summary>
    /// Increases the speed of the game when the patient returns
    /// </summary>
    public UnityEvent UpdateSpeed;

    /// <summary>
    /// Tracks when this object should be disabled
    /// </summary>
    private bool isEnabled = true;

    /// <summary>
    /// Tracks the current speed multiplier
    /// </summary>
    private float currentSpeed;

    /// <summary>
    /// Start should spawn the 3 initial patients
    /// </summary>
    private void Start()
    {
        SpawnPatient(0);
        SpawnPatient(1);
        SpawnPatient(2);
    }

    /// <summary>
    /// Spawns a new patient and sets their target destination from the leftPoint in front of the desk
    /// </summary>
    /// <param name="newDestination"></param>
    /// <returns></returns>
    public Patient SpawnPatient(int newDestination)
    {
        Patient newPatient = new Patient();

        newPatient.destinationPoint = new Vector3(leftPoint.transform.position.x + xPatientDistance * newDestination, leftPoint.transform.position.y, leftPoint.transform.position.z);
        newPatient.patientNum = newDestination;
        
        //Decides if the patient should spawn and return to the left of the building or the right
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

        //randomly generates which patient from the patientTypes array should be spawned and trakcs that number
        int spawnNumber = UnityEngine.Random.Range(0, patientTypes.Length);

        //These update all of the different pieces of information the patient needs
        newPatient.illness = patientTypes[spawnNumber].illness;
        newPatient.maxTime = defaultMaxTime - (Mathf.Sqrt(currentSpeed * maxTimeSpeedMultiplier));
        Debug.Log("Max time: " + newPatient.maxTime);
        newPatient.velocity = baseVelocity + (Mathf.Sqrt(currentSpeed * velocitySpeedMultiplier));
        Debug.Log("Velocity: " + newPatient.velocity);
        newPatient.acceleration = newPatient.velocity * 2;

        //Spawns the new patient
        newPatient.model = Instantiate(patientTypes[spawnNumber].model, nextSpawn.transform.position, Quaternion.identity);

        //This is used to transfer the patient's information to the new patient
        AddSpawnListener(newPatient.model);
        PatientSpawned?.Invoke(newPatient);
        RemoveSpawnListener(newPatient.model);

        //Tells other scripts what patient was spawned
        NewPatient?.Invoke(newPatient.model);

        patientNumber++;

        return newPatient;
    }

    /// <summary>
    /// Adds a patient as a listener to the PatientSpawned event
    /// </summary>
    /// <param name="newObject"></param>
    public void AddSpawnListener(GameObject newObject)
    {
        PatientSpawned.AddListener(newObject.GetComponent<PatientAI>().SetPatient);
    }

    /// <summary>
    /// removes a patient from being a listener to the PatientSpawned event.
    /// </summary>
    /// <param name="removingObject"></param>
    public void RemoveSpawnListener(GameObject removingObject)
    {
        PatientSpawned.RemoveListener(removingObject.GetComponent<PatientAI>().SetPatient);
    }

    /// <summary>
    /// Tells the speed controller to increase the speed and spawns a new patient given the returned patients destination point
    /// </summary>
    /// <param name="returnedPatient"></param>
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

    /// <summary>
    /// Disable the script from spawning more patients
    /// </summary>
    /// <param name="newVal"></param>
    public void ChangeEnabled(bool newVal)
    {
        isEnabled = newVal;
    }

    /// <summary>
    /// Update the speed multiplier of the game
    /// </summary>
    /// <param name="newSpeed"></param>
    public void ChangeSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
}

