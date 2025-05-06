using UnityEngine;
using UnityEngine.Events;

public class MedicineLifeTracker : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;

    private int currentlives;

    public UnityEvent GameOver;

    public UnityEvent<string> NewTotal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentlives = maxLives;
        NewTotal?.Invoke("Lives: " + currentlives);
    }

    public void LoseLife()
    {
        currentlives--;
        NewTotal?.Invoke("Lives: " + currentlives);

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
