using UnityEngine;

[System.Serializable]
public class Patient
{
    public GameObject model;
    public string illness;
    [HideInInspector] public Vector3 destinationPoint;
    [HideInInspector] public int patientNum;
    [HideInInspector] public GameObject returnPoint;
}
