using UnityEngine;
using UnityEngine.Events;

public class SpeedScript : MonoBehaviour
{
    [SerializeField] private float increaseSpeedMultiplier = .5f;
    private float currentSpeedMultiplier = 0;

    public UnityEvent<float> SpeedChanged;

    public void UpdateSpeed()
    {
        currentSpeedMultiplier += increaseSpeedMultiplier;

        SpeedChanged.Invoke(currentSpeedMultiplier);
    }

    public void NewSpeedListener(GameObject newListener)
    {
        
    }
}
