using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float fadeDuration = 1f;
    private AudioSource audioJingle;

    private bool isInside = false;
    private Coroutine currentFadeCoroutine;

    private void Start()
    {
        audioJingle = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("change music");
            ToggleAudio();
            audioJingle.Play();
        }


    }
    public void ToggleAudio()
    {
        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

        if (isInside)
        {
            currentFadeCoroutine = StartCoroutine(CrossfadeAudio("OutsideVolume", "InsideVolume"));
            isInside = false;
        }
        else
        {
            currentFadeCoroutine = StartCoroutine(CrossfadeAudio("InsideVolume", "OutsideVolume"));
            isInside = true;
        }
    }

    public void ToggleOutro()
    {
        fadeDuration = 2f;

        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

            currentFadeCoroutine = StartCoroutine(CrossfadeAudio("OutroVolume", "MusicVolume"));
    }

    public void ToggleSFX()
    {
        fadeDuration = 4f;

        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

            currentFadeCoroutine = StartCoroutine(CrossfadeSfx("SFXVolume"));
    }

    private IEnumerator CrossfadeAudio(string fadeInSource, string fadeOutSource)
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / fadeDuration;

            audioMixer.SetFloat(fadeInSource, Mathf.Lerp(-80f, 0f, normalizedTime));
            audioMixer.SetFloat(fadeOutSource, Mathf.Lerp(0f, -80f, normalizedTime));

            yield return null;
        }

        audioMixer.SetFloat(fadeInSource, 0f);
        audioMixer.SetFloat(fadeOutSource, -80f);

        currentFadeCoroutine = null;
    }

    private IEnumerator CrossfadeSfx(string fadeOutSource)
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / fadeDuration;

            audioMixer.SetFloat(fadeOutSource, Mathf.Lerp(0f, -80f, normalizedTime));

            yield return null;
        }

        audioMixer.SetFloat(fadeOutSource, -80f);

        currentFadeCoroutine = null;
    }
}