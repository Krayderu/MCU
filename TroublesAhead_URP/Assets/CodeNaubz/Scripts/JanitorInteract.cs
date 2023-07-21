using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class JanitorInteract : StepInteractObject
{
    public Flowchart flowchart;
    public Animator animator;
    [SerializeField] private FocusMode focusMode;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }


    public override void StepInteract()
    {
        focusMode.EnableFocusMode();
        #region StoryStep
        if (playerController.step == 4)
        {
            flowchart.ExecuteBlock("Step0");
           
        }

        if(playerController.step == 5)
        {
            flowchart.ExecuteBlock("Step0.5");
        }

        if (playerController.step >= 8)
        {
            flowchart.ExecuteBlock("Step2");
        }

        if (playerController.step > 5 && playerController.step < 8 && playerController.hintStep <5)
        {
            flowchart.ExecuteBlock("Step1");
        }
        #endregion

        #region HintStep
        if (playerController.step == 5 && playerController.hintStep == 3)
        {
            GetHint();
        }

        if (playerController.step == 6 && playerController.hintStep == 5)
        {
            GetHint();
        }
        #endregion


        playerController.janitorFound = true;


    }

    public void GetHint()
    {
        flowchart.ExecuteBlock("Hint" + playerController.hintStep);
    }

}
