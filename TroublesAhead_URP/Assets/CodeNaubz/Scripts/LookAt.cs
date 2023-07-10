using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    public bool isLooking = true;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (isLooking)
        {
            transform.LookAt(target.transform);
        }

    }

    void CallLooking()
    {
        if (isLooking)
        {
            isLooking = false;
            animator.enabled = true;
        }
        else
        {
            isLooking = true;
            animator.enabled = false;
        }
    }
}
