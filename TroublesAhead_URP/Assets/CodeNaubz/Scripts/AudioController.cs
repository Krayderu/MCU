using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float fadeDuration = 1f;

    private bool isInside = false;
    private Coroutine currentFadeCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ToggleAudio();
        }


    }
    public void ToggleAudio()
    {
        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

        if (isInside)
        {
            currentFadeCoroutine = StartCoroutine(CrossfadeAudio("OutsideVolume", "InsideVolume", 1f, 0f));
            isInside = false;
        }
        else
        {
            currentFadeCoroutine = StartCoroutine(CrossfadeAudio("InsideVolume", "OutsideVolume", 1f, 0f));
            isInside = true;
        }
    }

    private IEnumerator CrossfadeAudio(string fadeInSource, string fadeOutSource, float fadeInTargetVolume, float fadeOutTargetVolume)
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / fadeDuration;

            audioMixer.SetFloat(fadeInSource, Mathf.Lerp(0f, fadeInTargetVolume, normalizedTime));
            audioMixer.SetFloat(fadeOutSource, Mathf.Lerp(1f, fadeOutTargetVolume, normalizedTime));

            yield return null;
        }

        audioMixer.SetFloat(fadeInSource, fadeInTargetVolume);
        audioMixer.SetFloat(fadeOutSource, fadeOutTargetVolume);

        currentFadeCoroutine = null;
    }
}