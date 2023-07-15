using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StoolSpotInteract : StepInteractObject
{
    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void StepInteract()
    {
        focusMode.EnableFocusMode();

        flowchart.ExecuteBlock("Step0");

        if(playerController.step == 11)
        {
            playerController.step = 12;
        }
    }

    public void StopInteract()
    {
        minimumStep = 50;

        outline.enabled = false;
    }
}