using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LevierInteract : StepInteractObject
{

    public Flowchart flowchart;
    public Animator animator;
    [SerializeField] private FocusMode focusMode;

    //MatChange
    public Light redLight;
    public Light greenLight;
    public GameObject objToChange;
    public Material newMaterial;
    public Material[] mat;
    Renderer rlRenderer;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rlRenderer = objToChange.GetComponent<Renderer>();
        mat = rlRenderer.materials;
    }

    public override void StepInteract()
    {
        focusMode.EnableFocusMode();

        flowchart.ExecuteBlock("Step0");


    }

    public void EndLever()
    {
        playerController.step = 4;

        ExitFocus();

        minimumStep = 50;
    }

    public void ChangeLight()
    {
        mat[0] = newMaterial;
        rlRenderer.materials = mat;
        redLight.enabled = false;
        greenLight.enabled = true;
    }

}
