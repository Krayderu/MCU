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

        base.Start();

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
        playerController.rb.useGravity = false;

        playerController.cl.enabled = false;

        player.transform.position = new Vector3(-14.6f, 1.5f, -28.05f);

        player.transform.eulerAngles = new Vector3(0f, 90f, 0f);
       // Camera.main.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void ExitCamtar()
    {

        playerController.rb.useGravity = true;

        playerController.cl.enabled = true;

        player.transform.position = new Vector3(-14.78f, 1.68f, -23.84f);

    }
}
