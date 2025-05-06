using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script should be attatched to an image UI object with a fill type image
/// </summary>
public class BarScript : MonoBehaviour
{
    private Image bar;

    /// <summary>
    /// What fill amount from 0-1 should the bar start at
    /// </summary>
    [SerializeField] private float startFill = 1f;

    void Start()
    {
        //this gets the first image component of the object this is attached to
        bar = GetComponent<Image>();

        //Sets the bar's fill equal to whatever you decide the starting value to be
        UpdateBar(startFill);
    }

    /// <summary>
    /// Change the fill amount of the attatched image
    /// </summary>
    /// <param name="newValue"></param>
    public void UpdateBar(float newValue)
    {
        bar.fillAmount = newValue;
    }
}
