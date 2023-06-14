using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [HideInInspector] public Outline outline;
    [HideInInspector] public GameObject player;
    [HideInInspector] public CharacterControllerScript playerController;

    public virtual void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        FindPlayer();
    }

    public virtual void Interact()
    {
        Debug.Log($"Interacting with {gameObject.name}!");
    }

    public virtual void EnterFocus()
    {
        outline.enabled = true;
    }

    public virtual void ExitFocus()
    {
        outline.enabled = false;
    }

    public CharacterControllerScript FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<CharacterControllerScript>();

        return playerController;
    }
}
