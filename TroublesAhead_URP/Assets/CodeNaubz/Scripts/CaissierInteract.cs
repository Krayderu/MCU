using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CaissierInteract : InteractObject
{

    public Flowchart flowchart;

    public override void Interact()
    {
        base.Interact();

        flowchart.ExecuteBlock("Hello");

    }

    private void Update()
    {
        //Debug.Log("Animator Parameter Value: " + animator.GetBool("Opening"));
    }
}
