using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Transform target;

    public bool isLooking = true;


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
        }
        else
        {
            isLooking = true;
        }
    }
}
