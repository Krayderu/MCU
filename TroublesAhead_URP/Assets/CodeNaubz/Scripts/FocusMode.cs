using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMode : MonoBehaviour
{
    private Quaternion originalRotation;
    private CharacterControllerScript characterControllerScript;

    private void Start()
    {
        characterControllerScript = GetComponent<CharacterControllerScript>();
    }

    public void EnableFocusMode()
    {
        // Disable camera rotation
        characterControllerScript.focusActif = true;

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableFocusMode()
    {
        characterControllerScript.focusActif = false;

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
