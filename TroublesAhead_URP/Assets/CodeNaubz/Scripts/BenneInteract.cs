using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BenneInteract : StepInteractObject
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

        playerController.step = 6;
    }

}
