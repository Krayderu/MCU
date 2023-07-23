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

        playerController.controller = playerController.GetComponent<CharacterController>();

        playerController.controller.enabled = false;

        playerController.footstep = playerController.GetComponent<AudioSource>();

        playerController.footstep.enabled = false;

        flowchart.ExecuteBlock("Step0");


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
        playerController.footstep.enabled = false;

        playerController.controller.enabled = false;

        player.transform.position = new Vector3(-14.6f, 1.5f, -27.9f);

        player.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        Camera.main.transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    public void ExitCamtar()
    {
        playerController.footstep.enabled = true;

        playerController.controller.enabled = true;

        player.transform.position = new Vector3(-14.78f, 1.68f, -23.84f);

    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
