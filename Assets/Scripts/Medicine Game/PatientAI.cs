using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using UnityEngine.Events;

public class PatientAI : MonoBehaviour
{
    private Patient patient;
    private string collidedMeds;
    private bool isMedicated = false;
    private bool isLeaving = false;
    private bool gameLost = false;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float despawnThreashHold;

    public UnityEvent CorrectMedicineCollided;
    public UnityEvent IncorrectMedicineCollided;
    public UnityEvent<Patient> PatientFinished;

    
    private float currentTime = 0;

    private void Start()
    {
        MovePatient(patient.destinationPoint);
        agent.SetDestination(patient.destinationPoint);
        CorrectMedicineCollided.AddListener(GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<MedicineScoreSciprt>().MedicineScoreUpdate);
        IncorrectMedicineCollided.AddListener(GameObject.FindGameObjectWithTag("LifeTracker").GetComponent<MedicineLifeTracker>().LoseLife);
        PatientFinished.AddListener(GameObject.FindGameObjectWithTag("PatientSpawner").GetComponent<PatientSpawnScript>().PatientReturned);

        agent.speed = patient.velocity;
        agent.acceleration = patient.acceleration;
    }

    private void Update()
    {
        if (isMedicated && agent.remainingDistance < despawnThreashHold)
        {
            PatientFinished.Invoke(patient);
            Destroy(gameObject);
            Debug.Log("is medicated destroy");
        }

        currentTime += Time.deltaTime;

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

    public Patient GetPatientInfo()
    {
        return patient;
    }

    public void SetPatient(Patient newPatient)
    {
        patient = newPatient;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isMedicated && collision.gameObject.CompareTag("medicine"))
        {
            collidedMeds = collision.gameObject.GetComponent<NewMedScript>().getIllness();

            if (collidedMeds == patient.illness)
            {
                CorrectMedicineCollided.Invoke();
            }
            else
            {
                IncorrectMedicineCollided.Invoke();
            }

            isLeaving = true;
            isMedicated = true;
            MovePatient(patient.returnPoint.transform.position);
        }
    }

    public void GameLost()
    {
        gameLost = true;
        isLeaving = true;
        MovePatient(patient.returnPoint.transform.position);
    }
}
