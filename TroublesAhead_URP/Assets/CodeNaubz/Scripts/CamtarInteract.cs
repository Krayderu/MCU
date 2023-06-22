using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CamtarInteract : InteractObject
{
    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;

    // Start is called before the first frame update
    public override void Start()
    {
        Debug.Log("sucemoi");

        base.Start();

        Debug.Log("sucemoi2");

        flowchart.ExecuteBlock("Step0");

        playerController.rb = playerController.GetComponent<Rigidbody>();

        playerController.rb.useGravity = false;

        playerController.cl = playerController.GetComponent<CapsuleCollider>();

        playerController.cl.enabled = false;

        
    }

    public override void Interact()
    {
        base.Interact();

        focusMode.EnableFocusMode();

        if(playerController.step < 13)
        {
            flowchart.ExecuteBlock("Step1");
        }

        else
        {
            flowchart.ExecuteBlock("Step2");
        }
    }

    public void EnterCamtar()
    {
       // player.transform.position = new Vector3(x, y, z);
    }

    public void ExitCamtar()
    {

        playerController.rb.useGravity = true;

        playerController.cl.enabled = true;

        player.transform.position = new Vector3(-8.8f, 2f, -14.35f);
    }
}
