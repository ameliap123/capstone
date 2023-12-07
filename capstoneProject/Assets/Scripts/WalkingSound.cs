using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public float stepDistance = 0.45f; // Distance to travel before playing next footstep sound
    public AudioClip[] footstepSounds; // Array holding different footstep sounds
    private float distanceCounter = 0f;
    private int currentFootstep = 0;
    public float footstepVolume = 0.25f; // Volume of the footstep sounds

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.01f || Mathf.Abs(verticalInput) > 0.01f)
        {
            distanceCounter += Time.deltaTime;

            if (distanceCounter >= stepDistance)
            {
                PlayFootstepSound();
                distanceCounter = 0f;
            }
        }
        else
        {
            distanceCounter = 0f; // Reset the counter if not moving
        }
    }

    void PlayFootstepSound()
    {
        if (footstepSounds.Length == 0)
        {
            Debug.LogWarning("No footstep sounds assigned!");
            return;
        }

        // Create a temporary AudioSource to control volume
        AudioSource tempAudio = gameObject.AddComponent<AudioSource>();
        tempAudio.volume = footstepVolume;

        // Play the footstep sound using the temporary AudioSource
        tempAudio.PlayOneShot(footstepSounds[currentFootstep]);

        // Destroy the temporary AudioSource after the sound has played
        Destroy(tempAudio, footstepSounds[currentFootstep].length);

        // Move to the next footstep sound in the array
        currentFootstep = (currentFootstep + 1) % footstepSounds.Length;
    }
}
