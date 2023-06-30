using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LighterStandInteract : InteractObject
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
        Debug.Log("Interaction successful");

        if (playerController.step < 0) return;

        base.Interact();

        focusMode.EnableFocusMode();

        flowchart.ExecuteBlock("Step0");

        if (playerController.step == 0)
        {
            playerController.step = 1;
        }

    }

}