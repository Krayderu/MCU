using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDetector : MonoBehaviour
{

    public GameObject[] doortotrigger;
    public float timer;
    public float timeelapsed;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            return;
        }
        else if(timer <= 0)//Si la porte est ouverte, on reset le timer avant que'elle ne se referme
        {

        }
        else
        {
            //ouvrir la porte si elle ne l'est pas déjà
            //lancer un timer pour qu'elle se referme après un certain lapse de temps
        }
    }
}
