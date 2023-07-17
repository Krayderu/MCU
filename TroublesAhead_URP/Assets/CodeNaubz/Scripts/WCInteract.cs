using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class WCInteract : InteractObject
{
    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;
    private bool isOpen = false;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (playerController.step < 0) return;

        base.Interact();

        focusMode.EnableFocusMode();

        if(playerController.step < 6)
        {
            flowchart.ExecuteBlock("Step0");
        }

        if (playerController.step == 6)
        {
            flowchart.ExecuteBlock("Step1");
        }

        if (playerController.step > 6 && (!isOpen))
        {
            flowchart.ExecuteBlock("Step2");
        }

        if (isOpen)
        {
            flowchart.ExecuteBlock("Step3");
        }


    }

    void OpenDoor()
    {
        isOpen = true;
    }


}
