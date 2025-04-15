using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    [SerializeField] private float gravityMultiplier = 1f;
    [SerializeField] private float xThrowMultiplier = 1f;
    [SerializeField] private float yThrowPower = 1f;
    [SerializeField] private float zThrowMultiplier = 1f;

    private bool medicineThrown = false;

    private Vector3 currentPosition;
    private Vector3 previousPosition;

    private float timer = 0;
    private float timerMax = .05f;

    private void Start()
    {
        currentPosition = transform.position;
        GetComponent<Rigidbody>().mass *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timerMax)
        {
            previousPosition = currentPosition;
            currentPosition = Input.mousePosition;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void ThrowMedicine(bool newState)
    {
        if (!medicineThrown)
        {
            medicineThrown = !newState;
            Vector3 force = new Vector3((currentPosition.x - previousPosition.x) * xThrowMultiplier, yThrowPower, (currentPosition.y - previousPosition.y) * zThrowMultiplier);

            GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
        }
    }
}
