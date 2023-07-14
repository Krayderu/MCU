using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomizeLightIntensity : MonoBehaviour
{
    public float intensityMin = 0.5f;
    public float intensityMax = 1.0f;
    public float randomizeInterval = 2.0f; // Interval between intensity randomization

    private Light pointLight;
    private float timer;

    private void Start()
    {
        // Get the reference to the point light
        pointLight = GetComponent<Light>();

        // Initialize the timer
        timer = randomizeInterval;
    }

    private void Update()
    {
        // Countdown the timer
        timer -= Time.deltaTime;

        // Check if it's time to randomize the intensity
        if (timer <= 0f)
        {
            // Randomize the intensity
            RandomizeIntensity();

            // Reset the timer
            timer = randomizeInterval;
        }
    }

    public void RandomizeIntensity()
    {
        // Generate a random value for the intensity
        float randomIntensity = Random.Range(intensityMin, intensityMax);

        // Apply the random value to the light intensity
        pointLight.intensity = randomIntensity;
    }
}