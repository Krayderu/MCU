using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LighterStandInteract : InteractObject
{

    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;
    public Animator animator;
    public float maxTime = 1;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        Debug.Log("Interaction successful");

        if (playerController.step < 0) return;

        base.Interact();

        focusMode.EnableFocusMode();

        flowchart.ExecuteBlock("Step0");

        if (playerController.step == 0)
        {
            playerController.step = 1;
        }


        animator.SetBool("isShake", true);

        StartCoroutine(CloseAfterTime(maxTime));

        
        

    }

    private IEnumerator CloseAfterTime(float maxTime)
    {
        yield return new WaitForSeconds(maxTime);
        animator.SetBool("isShake", false);
        yield return null;
    }

}
