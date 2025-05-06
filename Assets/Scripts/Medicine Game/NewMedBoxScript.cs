using UnityEngine;
using UnityEngine.Events;

public class NewMedBoxScript : MonoBehaviour
{
    [SerializeField] private float xSpawnOffset;
    [SerializeField] private float ySpawnOffset;
    [SerializeField] private float zSpawnOffset;

    /// <summary>
    /// The prefab that the medicine box should spawn
    /// </summary>
    [SerializeField] private GameObject medicine;

    [SerializeField] private GameObject medicinePoint;

    /// <summary>
    /// Stores the medicine object that is spawned
    /// </summary>
    private GameObject newMedicine;

    /// <summary>
    /// Invoked when a new medicine is spawned
    /// </summary>
    public UnityEvent<GameObject> MedicineCreated;

    /// <summary>
    /// Stores if the button is pressed
    /// </summary>
    private bool pressState = false;

    [SerializeField] private bool isCurrentMed = false;

    /// <summary>
    /// Change the press state of the medicine box
    /// </summary>
    /// <param name="newState"></param>
    public void changeState(bool newState)
    {
        pressState = newState;
    }

    /// <summary>
    /// Detects when the player clicks on the object in the scene
    /// </summary>
    private void OnMouseDown()
    {
        Vector3 spawnPoint = new Vector3();
        spawnPoint.x = gameObject.transform.position.x + xSpawnOffset;
        spawnPoint.y = gameObject.transform.position.y + ySpawnOffset;
        spawnPoint.z = gameObject.transform.position.z + zSpawnOffset;

        //Once we know where it spawns we instantiate the object at that position, which is stored in newMedicine
        newMedicine = Instantiate(medicine, spawnPoint, Quaternion.identity);
        //Finally we invoke this event to tell other scripts that a new medicine has been created
        MedicineCreated?.Invoke(newMedicine);

        isCurrentMed = true;
    }

    public void DestroyMedicine()
    {
        if (isCurrentMed)
        {
            Destroy(newMedicine);
            isCurrentMed = false;
        }
    }
}
