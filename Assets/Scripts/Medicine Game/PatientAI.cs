using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class PatientAI : MonoBehaviour
{
    private Patient patient;

    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        MovePatient(patient.destinationPoint);
        agent.SetDestination(patient.destinationPoint);
    }

    public void MovePatient(Vector3 destination)
    {
        Debug.Log("Move Patient says its: " + patient.patientNum);
        agent.SetDestination(destination);        
    }

    public Patient GetPatientInfo()
    {
        return patient;
    }

    public void SetPatient(Patient newPatient)
    {
        Debug.Log(newPatient.patientNum);

        patient = newPatient;
    }
}
