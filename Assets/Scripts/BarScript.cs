using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private Image bar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bar = GetComponent<Image>();
        UpdateBar(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBar(float newValue)
    {
        bar.fillAmount = newValue;
    }
}
