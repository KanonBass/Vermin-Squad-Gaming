
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public List<OptionsAndAnswers> OnA;
    public GameObject[] options;
    public int currentOption = -1;
    List<int> shuffledOptions = new List<int>();
    public int previousOption = -1;
    public UnityEvent Won;
    public UnityEvent TimeOut;



    public TextMeshProUGUI OptionTxt;
    public TextMeshProUGUI ScoreTxt;
    public TextMeshProUGUI LosingTxt;
    public ScoreTracker scoreTracker;
    


    private void Start() //Whenever the game starts it instantly starts the option randomiser.
    {
           GenerateOption();
    }

   
    public void Retry() //Reloads the entire scene, assigned to both retry buttons in the win and lose panels.
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
   
 
    public void Correct() 
    {
      
        GenerateOption();
        if (scoreTracker.GetScore() >= scoreTracker.GetMaxScore()) 
        {
            Won.Invoke();
        }
        else if (scoreTracker.GetScore() <= scoreTracker.GetMinScore())
        {
            TimeOut.Invoke();
        }
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = OnA[currentOption].Answers[i];
            


            if (OnA[currentOption].CorrectOption == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }


    void ShuffleOptions()
    {
        shuffledOptions.Clear();

        for (int i = 0; i < OnA.Count; i++)
        {
            shuffledOptions.Add(i);
        }

        
        for (int i = 0; i < shuffledOptions.Count; i++)
        {
            int randIndex = Random.Range(i, shuffledOptions.Count);
            int temp = shuffledOptions[i];
            shuffledOptions[i] = shuffledOptions[randIndex];
            shuffledOptions[randIndex] = temp;
        }

        
        if (shuffledOptions.Count > 1 && shuffledOptions[0] == previousOption)
        {
            
            int temp = shuffledOptions[0];
            shuffledOptions[0] = shuffledOptions[1];
            shuffledOptions[1] = temp;
        }
    }

    void GenerateOption()
    {
        
        if (shuffledOptions.Count == 0)
        {
            ShuffleOptions();
        }

        currentOption = shuffledOptions[0];
        shuffledOptions.RemoveAt(0);

        
        if (currentOption == previousOption && OnA.Count > 1)
        {
            GenerateOption(); 
            return;
        }

        previousOption = currentOption;

        OptionTxt.text = OnA[currentOption].Option;
        SetAnswers();
    }

}