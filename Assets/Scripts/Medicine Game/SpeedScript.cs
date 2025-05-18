using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Script to track the speed increase of the medicine game
/// </summary>
public class SpeedScript : MonoBehaviour
{
    /// <summary>
    /// How quickly should the speed increase
    /// </summary>
    [SerializeField] private float increaseSpeedMultiplier = .5f;

    //Speed starts at 0
    private float currentSpeedMultiplier = 0;

    /// <summary>
    /// Update other objects with the new speed
    /// </summary>
    public UnityEvent<float> SpeedChanged;

    /// <summary>
    /// Update the speed of the game
    /// </summary>
    public void UpdateSpeed()
    {
        currentSpeedMultiplier += increaseSpeedMultiplier;

        SpeedChanged.Invoke(currentSpeedMultiplier);
    }
}
