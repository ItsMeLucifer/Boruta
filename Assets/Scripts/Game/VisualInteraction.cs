using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualInteraction : MonoBehaviour
{
    private bool seen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VisualInteractionWithThisObject()
    {
        if (seen) return;
        GetComponent<Animator>().SetTrigger("seen");
        seen = true;
    }
}
