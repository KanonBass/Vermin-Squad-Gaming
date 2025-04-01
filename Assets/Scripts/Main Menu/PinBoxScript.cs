using TMPro;
using UnityEngine;

public class PinBoxScript : MonoBehaviour
{
    TMP_Text pin;

    private void Start()
    {
        pin = GetComponent<TMP_Text>();
    }

    public void UpdatePinBox(string newNum)
    {
        pin.text = pin.text + newNum;
    }

    private void OnEnable()
    {
        pin.text = "";
    }
}
