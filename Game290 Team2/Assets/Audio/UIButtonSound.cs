using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioManager != null)
        {
            audioManager.PlayHoverSound();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioManager != null)
        {
            audioManager.PlayClickSound();
        }
    }
}
