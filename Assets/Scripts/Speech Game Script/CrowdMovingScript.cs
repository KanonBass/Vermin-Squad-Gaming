using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Unity.Mathematics;
using Unity.AI;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class CrowdMovingScript : MonoBehaviour
{
    public GameObject CrowdPrefab1;

    [SerializeField] private GameObject leftPointObject;
    [SerializeField] private GameObject rightPointObject;
    [SerializeField] private GameObject startPointObject;

    private Transform leftTransform;
    private Transform rightTransform;
    private Transform startTransform;


    [SerializeField] private int crowdRowLimit;
    [SerializeField] private int crowdColumnLimit;
    [SerializeField] private float xCrowdOffset;
    [SerializeField] private float zCrowdOffset;
    [SerializeField] private GameObject pointTracker;

    private int totalMembers;
    private NavMeshAgent[] crowdArray;
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
        
        crowdArray = new NavMeshAgent[totalMembers];

        currentPercent = startScore / maxScore;
        
        for (int i = 0; i < totalMembers; i++)
        {
            if (Mathf.Pow(-1f, (float)i) > 0)
            {
                crowdArray[i] = Instantiate(CrowdPrefab1, leftPointObject.transform.position, Quaternion.identity).GetComponent<NavMeshAgent>();
            }
            else
            {
                crowdArray[i] = Instantiate(CrowdPrefab1, rightPointObject.transform.position, Quaternion.identity).GetComponent<NavMeshAgent>();
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
                crowdArray[i].SetDestination(new Vector3(startTransform.position.x - 1 * (xCrowdOffset*(i%crowdColumnLimit)), startTransform.position.y, startTransform.position.z + 1 * (zCrowdOffset*(Mathf.Floor(i/crowdColumnLimit))))); 
            }
            else
            {
                if (Mathf.Pow(-1f, (float)i) > 0)
                {
                    crowdArray[i].SetDestination(leftTransform.position);
                }
                else
                {
                    crowdArray[i].SetDestination(rightTransform.position);
                }
            }
        }
    }
}
