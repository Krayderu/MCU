using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepInteractObject : InteractObject
{
    public int minimumStep;


    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (playerController.step < minimumStep) return;

        base.Interact();
        StepInteract();
        

    }

    public override void EnterFocus()
    {
        if (playerController.step >= minimumStep)
        {
            outline.enabled = true;
        }

    }

    public override void ExitFocus()
    {
        if (playerController.step >= minimumStep)
        {
            outline.enabled = false;
        }
    }

    public virtual void StepInteract()
    {
        Debug.Log("e");
    }
}
