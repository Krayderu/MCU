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

        if(playerController.step > 1 && playerController.step < 10 && playerController.janitorFound == false) // ICI
        {
            flowchart.ExecuteBlock("Step2");
        }

        if (playerController.step > 1 && playerController.step < 10 && playerController.janitorFound == true) // ICI
        {
            flowchart.ExecuteBlock("Step3");
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

        if (playerController.step == 6 && playerController.hintStep == 4)
        {
            GetHint();
        }

        if (playerController.step == 6 && playerController.hintStep == 5)
        {
            GetHint();
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
    public void GetHint()
    {
        flowchart.ExecuteBlock("Hint" + playerController.hintStep);
    }

    

}
