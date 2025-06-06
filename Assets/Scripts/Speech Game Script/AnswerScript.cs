using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;   
public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public OptionManager optionManager;
    public UnityEvent<float> optionSelected;
    [SerializeField] private float scoreValue = 2;
    [SerializeField] private AudioSource CheerAudio;
    [SerializeField] private AudioSource BooAudio;


    public void Answer()
    {
        if (isCorrect)
        {
            optionSelected?.Invoke(scoreValue);
            Debug.Log("Correct Answer");
            optionManager.Correct();
            CheerAudio.Play();
            BooAudio.Stop();



        }
        else
        {
            optionSelected?.Invoke(-scoreValue);
            Debug.Log("Wrong Answer");
            optionManager.Correct();
            BooAudio.Play();
            CheerAudio.Stop();
        }
}
}
