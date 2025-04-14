
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public List<OptionsAndAnswers> OnA;
    public GameObject[] options;
    public int currentOption;
    

   // public GameObject GamePanel;
   // public GameObject GoPanel;

    public TextMeshProUGUI OptionTxt;
    public TextMeshProUGUI ScoreTxt;
    public ScoreTracker scoreTracker;
    


    private void Start()
    {

       // GoPanel.SetActive(false);
           generateOption();
    }

   /* public void SwitchGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } */ 

    void GameOver()
    {
        //GamePanel.SetActive(false);
        //GoPanel.SetActive(true);

    }
    public void correct()
    {
        OnA.RemoveAt(currentOption);
        generateOption();
        ScoreTxt.text = "Score: " + scoreTracker.GetScore();
    } 
    void setAnswers()
    {
    for (int  i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = OnA[currentOption].Answers[i];
            if (OnA [currentOption].CorrectOption == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
         }
    }

    void generateOption()
    {
        if (OnA.Count > 0)
        {


            currentOption = Random.Range(0, OnA.Count);

            OptionTxt.text = OnA[currentOption].Option;
            setAnswers();
            
        }
        else
        {
            Debug.Log("Out of Options");
            GameOver();
        }
    }
}
