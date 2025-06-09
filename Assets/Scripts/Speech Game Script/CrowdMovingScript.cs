using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Unity.Mathematics;
using Unity.AI;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System;

/// <summary>
/// Script used to move the crowd in Speech minigame into rows and columns
/// </summary>
public class CrowdMovingScript : MonoBehaviour
{
    /// <summary>
    /// This is the object the script spawns
    /// </summary>
    public List<GameObject> Prefab;

    /// <summary>
    /// Point on the left side of the stage where inactive crowd gathers
    /// </summary>
    [SerializeField] private GameObject leftPointObject;
    /// <summary>
    /// Point on the right side of the stage where inactive crowd gathers
    /// </summary>
    [SerializeField] private GameObject rightPointObject;
    /// <summary>
    /// Point o
    /// </summary>
    [SerializeField] private GameObject startPointObject;

    //These are the transforms of the different points
    private Transform leftTransform;
    private Transform rightTransform;
    private Transform startTransform;

    /// <summary>
    /// Number of columns the crowd forms (in the x direction)
    /// </summary>
    [SerializeField] private int crowdRowLimit;
    /// <summary>
    /// Number of rows the crowd forms (in the z direction)
    /// </summary>
    [SerializeField] private int crowdColumnLimit;
    /// <summary>
    /// Distance between the columns of the crowd (x direction)
    /// </summary>
    [SerializeField] private float crowdColumnOffset;
    /// <summary>
    /// Distance between the rows of the crowd (z direction)
    /// </summary>
    [SerializeField] private float crowdRowOffset;
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject pointTracker;

    private int totalMembers;
    private GameObject[] crowdArray;
    private int currentMembers;

    private float maxScore;
    private float currentScore;
    private float startScore;
    private float currentPercent;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxScore = pointTracker.GetComponent<ScoreTracker>().GetMaxScore();
        currentScore = pointTracker.GetComponent<ScoreTracker>().GetScore();
        startScore = currentScore;

        Debug.Log($"start score {currentScore}");

        leftTransform = leftPointObject.transform;
        rightTransform = rightPointObject.transform;
        startTransform = startPointObject.transform;

        totalMembers = crowdRowLimit * crowdColumnLimit;
        
        crowdArray = new GameObject[totalMembers];

        currentPercent = startScore / maxScore;

        for (int i = 0; i < totalMembers; i++)
        {
            if (Mathf.Pow(-1f, (float)i) > 0)
            {
                crowdArray[i] = Instantiate(Prefab[UnityEngine.Random.Range(0, Prefab.Count)], leftPointObject.transform.position, Quaternion.identity);
              
            }
            else
            {
                crowdArray[i] = Instantiate(Prefab[UnityEngine.Random.Range(0, Prefab.Count)], rightPointObject.transform.position, Quaternion.identity);
            }
        }

        MoveCrowd();
    }

    public void MoveCrowd()
    {
        Debug.Log("Crowd Move Called");

        currentScore = pointTracker.GetComponent<ScoreTracker>().GetScore();
        currentPercent = currentScore / maxScore;

        Debug.Log(currentScore);
        Debug.Log(currentPercent);

        currentMembers = (int) (totalMembers * currentPercent);

        Debug.Log(currentMembers);

        for (int i = 0; i < totalMembers; i++)
        {
            if (i <= currentMembers)
            {
                crowdArray[i].GetComponent<NavMeshAgent>().SetDestination(new Vector3(startTransform.position.x - 1 * (crowdColumnOffset * (i%crowdColumnLimit)), startTransform.position.y, startTransform.position.z + 1 * (crowdRowOffset * (Mathf.Floor(i/crowdColumnLimit)))));
            }
            else
            {
                if (Mathf.Pow(-1f, (float)i) > 0)
                {
                    crowdArray[i].GetComponent<NavMeshAgent>().SetDestination(leftTransform.position);
                }
                else
                {
                    crowdArray[i].GetComponent<NavMeshAgent>().SetDestination(rightTransform.position);
                }
            }
        }
    }
}
