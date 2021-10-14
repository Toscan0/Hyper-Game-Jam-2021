using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SelfDestroy : MonoBehaviour, IDestroyable
{
    [SerializeField]
    private AudioClip destroyedSound;

    private bool firstTime = true;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DestroyObj()
    {
        // Only destroys the obj one time
        if (firstTime)
        {
            PlaySound();

            Destroy(gameObject, 1);
        }
    }

    private void PlaySound()
    {
        audioSource.clip = destroyedSound;
        audioSource.Play();
    }
}
