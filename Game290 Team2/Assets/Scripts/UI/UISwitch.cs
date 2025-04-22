using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public bool isActive = false;
    AudioManager audioManager;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
          
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Switch()
{
    if (isActive)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        isActive = false;

        if (audioManager != null)
            audioManager.PlayNoClickSound(); 
    }
    else
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        isActive = true;

        if (audioManager != null)
            audioManager.PlayClickSound(); 
    }
}

}
