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

        FindPlayer();
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

    }

}
