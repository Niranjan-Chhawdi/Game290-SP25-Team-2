using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference = https://www.youtube.com/watch?v=JmLIxXiKFqI&t=319s

public class CSE_Test : CutSceneElementBase
{
    public override void Execute()
    {
        StartCoroutine(WaitAndAdvance());
        Debug.Log("Executing" + name);
    }
}
