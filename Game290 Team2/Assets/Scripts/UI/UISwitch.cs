using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public bool isActive = false;
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Switch()
    {
        if (isActive)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            isActive = false;
        }
        else
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            isActive = true;
        }
    }
}
