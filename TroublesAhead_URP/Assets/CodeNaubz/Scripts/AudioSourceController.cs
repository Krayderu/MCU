using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceController : MonoBehaviour
{
    public AudioClip ostIntro;
    public AudioClip ostLoop;
    void Start()
    {
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        GetComponent<AudioSource>().clip = ostIntro;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        GetComponent<AudioSource>().clip = ostLoop;
        GetComponent<AudioSource>().Play();
    }
}
