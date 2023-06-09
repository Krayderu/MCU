using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Animator animator;

    public void TriggerAnimation()
    {
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
        Debug.Log("Animator Parameter Value: " + animator.GetBool("Opening"));
    }
}
