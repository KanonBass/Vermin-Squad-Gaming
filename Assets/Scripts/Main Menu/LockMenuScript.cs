using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine.Events;

public class LockMenuScript : MonoBehaviour
{
    private int previousMenu;
    private object previousMenuObj;

    private string key = "Pin";
    private string pin = "";

    public UnityEvent<string> PinEvent;

    public void StoreScene()
    {
        previousMenu = gameObject.GetInstanceID();
        PlayerPrefs.SetInt("previousMenu", previousMenu);
        Debug.Log(previousMenu);
    }

    public void CancelButton()
    {
        gameObject.SetActive(false);
        ((GameObject)previousMenuObj).SetActive(true);
    }

    public void ButtonPress(string button)
    {
        pin += button;
        PinEvent.Invoke(button);

        if (pin.Length == 4)
        {
            SavePin();
        }
    }

    private void SavePin()
    {
        PlayerPrefs.SetString(key, pin);
        gameObject.SetActive(false);
        ((GameObject)previousMenuObj).SetActive(true);

        Debug.Log("This is the pin that was stored: " + pin);
        pin = "";
    }
}
