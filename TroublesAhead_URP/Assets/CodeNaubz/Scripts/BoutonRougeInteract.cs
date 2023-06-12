using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonRougeInteract : InteractObject
{
    public Animator animator;

    public override void Start()
    {
        base.Start();

        FindPlayer();
    }

    public override void Interact()
    {
        base.Interact();
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

    private void Update()
    {
        //Debug.Log("Animator Parameter Value: " + animator.GetBool("Opening"));
    }
}
