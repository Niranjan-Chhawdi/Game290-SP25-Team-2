using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//reference = https://www.youtube.com/watch?v=JmLIxXiKFqI&t=319s
public class CSE_PopUpDialogue : CutSceneElementBase
{
    
    
  
    [TextArea]
    [SerializeField] private string dialogue;
    [SerializeField] private TextPosition textPosition;

    [SerializeField] private Animator anim;
    [SerializeField] private TMP_Text popUpText;

    private bool isTextActive;


    public override void Execute()
    {
        SetTextPosition();

        anim.Play("FadeIn");
        isTextActive = true;
        popUpText.text = dialogue;
    }
    
    private void Update()
    {
        if(Input.GetButtonDown("Interact") && isTextActive)
                anim.Play("FadeOut");

    }
    
    public void SetTextPosition()
    {
        RectTransform rectTransform = popUpText.rectTransform;

        switch (textPosition)
        {
            case TextPosition.Top:
                rectTransform.anchoredPosition = new Vector2(0, 130);
                break;
            case TextPosition.Middle:
                rectTransform.anchoredPosition = new Vector2(0, 0);
                break;
            case TextPosition.Bottom:
                rectTransform.anchoredPosition = new Vector2(0, -130);
                break;

        }

      
    }

}

public enum TextPosition
{
    Top,
    Middle,
    Bottom,
}