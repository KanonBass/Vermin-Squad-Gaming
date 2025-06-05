using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_Down_Audio : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] private AudioSource clickaudio; //The audio that you selected (Drag in explorer)

    public void OnPointerDown(PointerEventData eventData) //When selected object is being pressed (not released)
    {
        clickaudio.Play();
    }
}
