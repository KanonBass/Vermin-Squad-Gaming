using UnityEngine;

/// <summary>
/// All the information necessary for a patient
/// </summary>
[System.Serializable]
public class Patient
{
    /// <summary>
    /// This is the model for the patient
    /// </summary>
    public GameObject model;
    /// <summary>
    /// The illness or medical issue the patient suffers from
    /// </summary>
    public string illness;

    /// <summary>
    /// Where the patient should move to initially
    /// </summary>
    [HideInInspector] public Vector3 destinationPoint;
    /// <summary>
    /// The patient's position from the left of the table in scene
    /// </summary>
    [HideInInspector] public int patientNum;

    /// <summary>
    /// Where the patient is meant to return when finished
    /// </summary>
    [HideInInspector] public GameObject returnPoint;
    /// <summary>
    /// The amount of time before the patient leaves without medicine
    /// </summary>
    [HideInInspector] public float maxTime;
    /// <summary>
    /// Speed of the patient
    /// </summary>
    [HideInInspector] public float velocity;
    /// <summary>
    /// Acceleration of the patient
    /// </summary>
    [HideInInspector] public float acceleration;
    /// <summary>
    /// The distance the patient will stop from its target destination
    /// </summary>
    [HideInInspector] public float stoppingDistance;
}
