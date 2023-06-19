using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CaissierInteract : InteractObject
{

    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;

    public override void Start()
    {
        base.Start();

    }

    public override void Interact()
    {
        if (playerController.step < 0) return;

        base.Interact();

        focusMode.EnableFocusMode();

        if(playerController.step == 0)
        {
            flowchart.ExecuteBlock("Step0");
        }

        if (playerController.step == 1)
        {
            flowchart.ExecuteBlock("Step1");
        }

        if(playerController.step > 1 && playerController.step < 10 && playerController.janitorFound == false)
        {
            flowchart.ExecuteBlock("Step2");
        }

        if (playerController.step > 1 && playerController.step < 10 && playerController.janitorFound == true)
        {
            flowchart.ExecuteBlock("Step3");
        }

    }

    public void NextStep()
    {
        playerController.step += 1;
    }

    

}
