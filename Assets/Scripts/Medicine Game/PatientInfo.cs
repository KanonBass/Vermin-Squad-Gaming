using UnityEngine;

public class PatientInfo : MonoBehaviour
{
    private Patient patient;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Patient GetPatientInfo()
    {
        return patient;
    }

    public void SetPatient(Patient newPatient)
    {
        patient = newPatient;
    }
}
