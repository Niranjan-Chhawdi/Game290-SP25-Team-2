using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this for UI components

public class ButtonSize : MonoBehaviour
{
    void Start()
    {
        Image buttonImage = GetComponent<Image>(); // Get the Image component
        RectTransform rect = GetComponent<RectTransform>(); // Get the RectTransform

        if (buttonImage != null && rect != null)
        {
            RectTransform imageRect = buttonImage.GetComponent<RectTransform>(); // Get the Image's RectTransform
            imageRect.sizeDelta = rect.sizeDelta; // Match sizes
        }
    }
}
