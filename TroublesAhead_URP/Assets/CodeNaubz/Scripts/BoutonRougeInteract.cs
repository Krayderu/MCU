using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonRougeInteract : InteractObject
{
    public Animator animator;

    public override void Interact()
    {
        base.Interact();


        if(animator.GetBool("Opening")==true)
        {
            animator.SetBool("Opening", false);
        }
        else
        {
            animator.SetBool("Opening", true);
        }
    }

    private void Update()
    {
        //Debug.Log("Animator Parameter Value: " + animator.GetBool("Opening"));
    }
}
