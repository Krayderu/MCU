using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMode : MonoBehaviour
{
    public GameObject player;
    public CharacterControllerScript playerController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<CharacterControllerScript>();
        
        
    }

    public void EnableFocusMode()
    {
        // Disable camera rotation
        playerController.focusActif = true;

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableFocusMode()
    {

        playerController.focusActif = false;

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
