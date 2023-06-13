using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{

    public Animator animator;
    public float maxTime = 3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("entred");
            animator.SetBool("isOpen", true);
            StartCoroutine(CloseAfterTime(maxTime));
        }
        

    }

    private IEnumerator CloseAfterTime(float maxTime)
    {
        yield return new WaitForSeconds(maxTime);
        animator.SetBool("isOpen", false);
        yield return null;
    }

}
