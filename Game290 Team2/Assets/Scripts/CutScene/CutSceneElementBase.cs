using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference = https://www.youtube.com/watch?v=JmLIxXiKFqI&t=319s
public class CutSceneElementBase : MonoBehaviour
{
    public float duration;
    private CutSceneHandler cutSceneHandler;

    public void Start()
    {
        cutSceneHandler = GetComponent<CutSceneHandler>();
            
    }

    public virtual void Execute()
    {

    }

    protected IEnumerator WaitAndAdvance()
    {
        yield return new WaitForSeconds(duration);
        cutSceneHandler.PlayNextElement();


    }
}
