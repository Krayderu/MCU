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

        

        if(playerController.step < 8)
        {
            focusMode.EnableFocusMode();

            flowchart.ExecuteBlock("Step0");
        }

        if(playerController.step == 8)
        {
            focusMode.EnableFocusMode();

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

        player.transform.position = new Vector3(7.66f, 9.13f, -80.754f);
    }

}
