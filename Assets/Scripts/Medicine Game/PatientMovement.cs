using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class PatientMovement : MonoBehaviour
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MovePatient(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
