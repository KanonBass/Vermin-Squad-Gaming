using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;

public class MedicineLifeTracker : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;

    private int currentlives;

    public UnityEvent GameOver;

    public UnityEvent<string> NewTotal;

    [SerializeField] private AudioSource WrongAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentlives = maxLives;
        if (LocalizationSettings.SelectedLocale.LocaleName == "English")
        {
            NewTotal?.Invoke("Lives: " + currentlives);
        }
        else
        {
            NewTotal?.Invoke("Levens: " + currentlives);
        }

    }

    public void LoseLife()
    {
        currentlives--;
        if (LocalizationSettings.SelectedLocale.LocaleName == "English")
        {
            NewTotal?.Invoke("Lives: " + currentlives);
        }
        else
        {
            NewTotal?.Invoke("Levens: " + currentlives);
        }
        WrongAudio.Play();


        if (currentlives == 0)
        {
            GameOver?.Invoke();
        }
    }

    public void AddListener(GameObject newListener)
    {
        GameOver.AddListener(newListener.GetComponent<PatientAI>().GameLost);
    }
}
