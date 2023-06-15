using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LevierInteract : StepInteractObject
{

    public Flowchart flowchart;
    public Animator animator;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void StepInteract()
    {
        flowchart.ExecuteBlock("Step0");


    }

}
