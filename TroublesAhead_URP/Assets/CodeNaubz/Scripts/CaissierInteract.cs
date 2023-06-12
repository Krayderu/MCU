using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CaissierInteract : InteractObject
{

    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;
    public bool flowchartBool;

    public override void Start()
    {
        base.Start();
        flowchartBool = flowchart.GetBooleanVariable("End");

    }


    public override void Interact()
    {
        base.Interact();

        focusMode.EnableFocusMode();
        flowchart.ExecuteBlock("Hello");



    }

    private void Update()
    {

        if (flowchartBool)
        {
            focusMode.DisableFocusMode();
        }
        Debug.Log(flowchartBool);
        //Debug.Log("Animator Parameter Value: " + animator.GetBool("Opening"));
    }
}
