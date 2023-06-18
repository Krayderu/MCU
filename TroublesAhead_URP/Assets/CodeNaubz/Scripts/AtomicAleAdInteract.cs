using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicAleAdInteract : StepInteractObject
{

    public Animator animator;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void StepInteract()
    {


        if (animator.GetBool("isOpen") == true)
        {
            animator.SetBool("isOpen", false);
        }
        else
        {
            animator.SetBool("isOpen", true);
        }

        if(playerController.step == 6)
        {
            playerController.step = 7;
        }

        minimumStep = 0;
    }
}
