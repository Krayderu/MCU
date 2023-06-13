using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonRougeInteract : StepInteractObject
{
    public Animator animator;

    public override void Start()
    {
        base.Start();
    }

    public override void StepInteract()
    {
        if(playerController.step == 0)
        {
            playerController.step = 1;
        }

        if(animator.GetBool("Opening")==true)
        {
            animator.SetBool("Opening", false);
        }
        else
        {
            animator.SetBool("Opening", true);
        }
    }

}
