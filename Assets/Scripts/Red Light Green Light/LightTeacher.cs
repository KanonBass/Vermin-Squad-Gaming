using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Script for the teacher in the red light minigame
/// </summary>
public class LightTeacher : MonoBehaviour
{
    [SerializeField] public AudioSource SpeakingAudio;
    [SerializeField] public AudioSource TurnAudio;


    /// <summary>
    /// Is the teacher looking at the player
    /// </summary>
    private bool isRed;

    /// <summary>
    /// Is the player currently reading
    /// </summary>
    private bool reading = false;

    /// <summary>
    /// Invoked if the player is caught by the teacher
    /// </summary>
    public UnityEvent Caught;

    //The material of the teacher which is used to change color, temporary for now
    [SerializeField] List<Material> _materials;
    [SerializeField] int index = 0;
    [SerializeField] int maxIndex = 1;

    //colors used for the states of the teacher, temporary
    private Color greenColor;
    private Color redColor;


    void Start()
    {
        //define the colors of the teacher using hexadecimal 
        ColorUtility.TryParseHtmlString("#33A93D", out greenColor);
        ColorUtility.TryParseHtmlString("#9F0400", out redColor);
        TeacherColorChange(false);
       // Book.SetActive(true);
       // OpenBook.SetActive(false);
    }

    /// <summary>
    /// Change if the teacher is currently looking at the player
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeTimeState(bool newState)
    {
        isRed = newState;
    }

    /// <summary>
    /// Change if the player is currently reading using mouse or touch
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeInputState(bool newState)
    {
        reading = newState;
        
    }

    /// <summary>
    /// Call when the grace period has ended to chack if the player is reading
    /// </summary>
    public void GraceEnd()
    {
        Debug.Log("grace Checked");

        if (reading)
        {
            Caught.Invoke();
            Debug.Log("You Lose");
        }
    }

    /// <summary>
    /// Change the color of the teacher, temporary
    /// </summary>
    /// <param name="isred"></param>
    public void TeacherColorChange(bool isred)
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material[] tmpMaterials = meshRenderer.materials;
        

        if (isred)
        {
            Debug.Log("material should be red");
            
            tmpMaterials[0] = _materials[1];
            meshRenderer.materials = tmpMaterials;
            transform.rotation = new quaternion(0,0,0,0);
            SpeakingAudio.Stop();
            TurnAudio.Play();

        }
        else
        {
            Debug.Log("material should be green");
            tmpMaterials[0] = _materials[0];
            meshRenderer.materials = tmpMaterials;
            transform.rotation = new quaternion(0, -180, 0, 0);
            SpeakingAudio.Play();

        }
    }
}
