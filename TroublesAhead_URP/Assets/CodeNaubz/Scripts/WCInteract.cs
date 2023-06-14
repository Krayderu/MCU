using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class WCInteract : InteractObject
{
    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (playerController.step < 0) return;

        base.Interact();

        focusMode.EnableFocusMode();

        if(playerController.step < 5)
        {
            flowchart.ExecuteBlock("Step0");
        }

        if (playerController.step == 5)
        {
            flowchart.ExecuteBlock("Step1");
        }

        if (playerController.step > 5)
        {
            flowchart.ExecuteBlock("Step2");
        }


    }


}
