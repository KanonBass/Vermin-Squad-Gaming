using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ReduceSound : MonoBehaviour
{
    [SerializeField] GameObject audioSource;
    private AudioSource source;

    [SerializeField] private float audioIncreaseRate;
    [SerializeField] private float audioDecreaseRate;
    [SerializeField] private float maxVolume;
    [SerializeField] private float minVolume;

    private bool isPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isPressed && (source.volume > minVolume))
        {
            source.volume -= audioDecreaseRate * Time.deltaTime;
        }
        else if (source.volume < maxVolume)
        {
            source.volume += audioIncreaseRate * Time.deltaTime;
        }
    }

    public void ChangePressState(bool newState)
    {
        Debug.Log("Volume Changed Input: " + newState);
        isPressed = newState;
    }
}
