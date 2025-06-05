using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_Down_Audio : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource clickaudio;

    public void OnPointerDown(PointerEventData eventData)
    {
        clickaudio.Play();
    }
}
