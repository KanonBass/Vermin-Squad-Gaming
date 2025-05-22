using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteHolding : MonoBehaviour
{
    private Volume volume;
    private VolumeProfile profile;
    private Vignette vignette;

    [SerializeField] private float vignetteIncreaseSpeed;
    [SerializeField] private float vignetteDecreaseSpeed;
    [SerializeField] private float maxVignette;

    private bool isPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume = GetComponent<Volume>();

        profile = volume.profile;

        if(profile.TryGet<Vignette>(out var temp))
        {
            
            vignette = temp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed && ((float)vignette.intensity) <= ((float)maxVignette))
        {
            vignette.intensity.value += vignetteIncreaseSpeed * Time.deltaTime;
        }
        else if ((float)vignette.intensity > 0f)
        {
            vignette.intensity.value = vignette.intensity.value - vignetteDecreaseSpeed * Time.deltaTime;
        }
    }

    public void ChangePressState(bool newState)
    {
        isPressed = newState;
    }
}
