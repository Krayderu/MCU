using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LevierInteract : StepInteractObject
{

    public Flowchart flowchart;
    public Animator animator;
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


    }

    public void EndLever()
    {
        playerController.step = 4;

        ExitFocus();

        minimumStep = 50;
    }

}
