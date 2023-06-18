using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EchelleInteract : InteractObject
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

        if(playerController.step < 8)
        {
            flowchart.ExecuteBlock("Step0");
        }

        if(playerController.step == 8)
        {
            flowchart.ExecuteBlock("Step1");
        }

        if(playerController.step > 8)
        {
            ClimbLadder();
        }

    }

    public void ClimbLadder()
    {
        Debug.Log("Ladder climbed !");
    }

}
