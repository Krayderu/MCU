using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Audio;

public class CaissierInteract : InteractObject
{

    public Flowchart flowchart;
    [SerializeField] private FocusMode focusMode;
    [SerializeField] AudioSource audioAvance;
    [SerializeField] AudioSource audioRecule;
    [SerializeField] AudioSource audioPorteBR;

    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (playerController.step < 0) return;

        base.Interact();

        focusMode.EnableFocusMode();
        #region StorySteps
        if (playerController.step == 0 && playerController.hintStep != 1)
        {
            flowchart.ExecuteBlock("Step0");
        }


        if (playerController.step == 1)
        {
            flowchart.ExecuteBlock("Step1");
        }

        if(playerController.step == 10)
        {
            flowchart.ExecuteBlock("Step4");
        }

        if(playerController.step > 10)
        {
            flowchart.ExecuteBlock("Step5");
        }


        #endregion
        #region HintSteps

        if (playerController.step == 0 && playerController.hintStep == 1)
        {
            GetHint();
        }

        if (playerController.step == 2 && playerController.hintStep == 2)
        {
            GetHint();
        }

        if (playerController.step == 3 && playerController.hintStep == 2)
        {
            flowchart.ExecuteBlock("DevComment");
        }

        if (playerController.step == 4 && playerController.hintStep == 2)
        {
            GetHint();
        }

        if (playerController.step == 6 && playerController.hintStep == 4)
        {
            GetHint();
        }

        if (playerController.step == 6 && playerController.hintStep == 5)
        {
            GetHint();
        }

        if (playerController.step == 7 && playerController.hintStep == 5)
        {
            flowchart.ExecuteBlock("WCDoor");
        }

        if (playerController.step == 5 && playerController.hintStep <= 3) 
        {
            flowchart.ExecuteBlock("Hint3");
        }


        if (playerController.step >=8 && playerController.step <10)
        {
            flowchart.ExecuteBlock("RoofHint");
        }
        #endregion
    }


    public void NextStep()
    {
        playerController.step += 1;
    }

    public void NextHint()
    {
        playerController.hintStep += 1;
    }

    public void SynchroLighter()
    {
        playerController.hintStep = 1;
    }

    public void SynchroDumpster()
    {
        playerController.hintStep = 4;
    }
    public void SynchroPoster()
    {
        playerController.hintStep = 5;
    }
    public void GetHint()
    {
         flowchart.ExecuteIfHasBlock("Hint" + playerController.hintStep); 
    }

    public void CallAvance()
    {
        audioAvance.Play();
    }

    public void CallRecule()
    {
        audioRecule.Play();
    }

    public void CallPorte()
    {
        audioPorteBR.Play();
    }



}
