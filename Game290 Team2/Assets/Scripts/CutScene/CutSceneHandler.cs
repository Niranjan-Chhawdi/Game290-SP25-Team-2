using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference = https://www.youtube.com/watch?v=JmLIxXiKFqI&t=319s

public class CutSceneHandler : MonoBehaviour
{

    private CutSceneElementBase[] cutsceneElement;
    private int index = -1;

    public void Start()
    {
        cutsceneElement = GetComponents<CutSceneElementBase>();
    }

    private void ExecuteCurrentElement()
    {
        if (index >= 0 && index < cutsceneElement.Length)
            cutsceneElement[index].Execute();
      
    }

    public void PlayNextElement()
    {
        index++;
        ExecuteCurrentElement();
    }
}
