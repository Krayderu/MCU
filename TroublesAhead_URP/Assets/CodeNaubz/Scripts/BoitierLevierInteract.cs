using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoitierLevierInteract : StepInteractObject
{

    public Animator animator;
    public new Collider collider;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void StepInteract()
    {
        animator.SetBool("isOpen", true);

        playerController.step = 3;

        ExitFocus();

        minimumStep = 50;

        collider.enabled = false;

    }


}
