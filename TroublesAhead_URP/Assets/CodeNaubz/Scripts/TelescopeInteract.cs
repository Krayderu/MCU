using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeInteract : StepInteractObject
{

    [SerializeField] private FocusMode focusMode;

    public bool isMoon = false;

    public GameObject moonUI;

    public GameObject canvas;

    public PauseMenu scriptCanvas;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        scriptCanvas = canvas.GetComponent<PauseMenu>();
    }

    public override void StepInteract()
    {
        if (isMoon)
        {
            focusMode.DisableFocusMode();
            moonUI.SetActive(false);
            isMoon = false;
            scriptCanvas.TextOff();

        }
        else
        {
            focusMode.EnableFocusMode();
            moonUI.SetActive(true);
            isMoon = true;
            scriptCanvas.TextOn();
        }
    }

}
