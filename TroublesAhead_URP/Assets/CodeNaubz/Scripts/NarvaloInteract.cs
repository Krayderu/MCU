using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NarvaloInteract : InteractObject
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

        base.Interact();

        focusMode.EnableFocusMode();

        flowchart.ExecuteBlock("Narvalo");

    }

}