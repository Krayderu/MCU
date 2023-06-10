using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private Outline outline;

    public virtual void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;

    }

    public virtual void Interact()
    {
        Debug.Log($"Interacting with {gameObject.name}!");
    }

    public void EnterFocus()
    {
        outline.enabled = true;
    }

    public void ExitFocus()
    {
        outline.enabled = false;
    }
}
