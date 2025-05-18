using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using UnityEngine.Events;

/// <summary>
/// Script to control individual patients
/// </summary>
public class PatientAI : MonoBehaviour
{
    /// <summary>
    /// Detail of this patient
    /// </summary>
    private Patient patient;


    private string collidedMeds;

    //Variables used to track the state of the patient
    private bool isMedicated = false;
    private bool isLeaving = false;
    private bool gameLost = false;

    /// <summary>
    /// NavmeshAgent component of this patient
    /// </summary>
    [SerializeField] private NavMeshAgent agent;

    /// <summary>
    /// The distance the patient will despawn at
    /// </summary>
    [SerializeField] private float despawnThreashHold;

    /// <summary>
    /// Trigger when the correct medicine hits the patient
    /// </summary>
    public UnityEvent CorrectMedicineCollided;
    /// <summary>
    /// Trigger when the incorrect medicine hits the patient
    /// </summary>
    public UnityEvent IncorrectMedicineCollided;
    /// <summary>
    /// Triggers when the patient is being despawned
    /// </summary>
    public UnityEvent<Patient> PatientFinished;

    /// <summary>
    /// The patient's timer to leave
    /// </summary>
    private float currentTime = 0;

    private void Start()
    {
        //The patient should move to the front of the desk
        MovePatient(patient.destinationPoint);
        agent.SetDestination(patient.destinationPoint);

        //The patient needs to be able to communicate information with different objects
        CorrectMedicineCollided.AddListener(GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<MedicineScoreSciprt>().MedicineScoreUpdate);
        IncorrectMedicineCollided.AddListener(GameObject.FindGameObjectWithTag("LifeTracker").GetComponent<MedicineLifeTracker>().LoseLife);
        PatientFinished.AddListener(GameObject.FindGameObjectWithTag("PatientSpawner").GetComponent<PatientSpawnScript>().PatientReturned);

        //Set the speed and acceleration to the correct values based on the current speed of the game
        agent.speed = patient.velocity;
        agent.acceleration = patient.acceleration;
    }

    private void Update()
    {
        //Destorys the patient when it is leaving
        if (isMedicated && agent.remainingDistance < despawnThreashHold)
        {
            PatientFinished.Invoke(patient);
            Destroy(gameObject);
            Debug.Log("is medicated destroy");
        }

        //updates the patient's timer
        currentTime += Time.deltaTime;

        //If the patient's time is up then it leaves
        if (!isLeaving && !gameLost && currentTime >= patient.maxTime)
        {
            MovePatient(patient.returnPoint.transform.position);
            IncorrectMedicineCollided.Invoke();
            isLeaving = true;
            isMedicated = true;
        }
    }

    
    public void MovePatient(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    /// <summary>
    /// Transfer information about the patient
    /// </summary>
    /// <returns></returns>
    public Patient GetPatientInfo()
    {
        return patient;
    }

    /// <summary>
    /// Sets the patient's information
    /// </summary>
    /// <param name="newPatient"></param>
    public void SetPatient(Patient newPatient)
    {
        patient = newPatient;
    }

    /// <summary>
    /// Detects when medicine collides with the patient
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        //Need to make sure that the patient hasn't already been medicated and that it is colliding with medicine
        if (!isMedicated && collision.gameObject.CompareTag("medicine"))
        {
            collidedMeds = collision.gameObject.GetComponent<NewMedScript>().getIllness();

            //Checks if the medicine is correct
            if (collidedMeds == patient.illness)
            {
                CorrectMedicineCollided.Invoke();
            }
            else
            {
                IncorrectMedicineCollided.Invoke();
            }

            //patient returns to its spawn point
            isLeaving = true;
            isMedicated = true;
            MovePatient(patient.returnPoint.transform.position);
        }
    }

    //When the game is over the patients should all stop accepting medicine and exit the building
    public void GameLost()
    {
        gameLost = true;
        isLeaving = true;
        MovePatient(patient.returnPoint.transform.position);
    }
}
