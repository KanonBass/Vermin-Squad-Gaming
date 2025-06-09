using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ReduceSound : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioSource;
   // private  List<AudioSource> source;

    [SerializeField] private float audioIncreaseRate;
    [SerializeField] private float audioDecreaseRate;
    [SerializeField] private float maxVolume;
    [SerializeField] private float minVolume;

    private bool isPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
      /*  for (int i = 0; i < audioSource.Count; i++)
        {
            source[i] = audioSource[i].GetComponent<AudioSource>();
        }*/
    }

    void Update()
    {
        for (int i = 0; i < audioSource.Count; i++)
        {
            if (isPressed && (audioSource[i].volume > minVolume))
            {
                audioSource[i].volume -= audioDecreaseRate * Time.deltaTime;
            }
            else if (audioSource[i].volume < maxVolume)
            {
                audioSource[i].volume += audioIncreaseRate * Time.deltaTime;
            }
        }
        
    }

    public void ChangePressState(bool newState)
    {
        Debug.Log("Volume Changed Input: " + newState);
        isPressed = newState;
    }
}
