using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SelfDestroy : MonoBehaviour, IDestroyable
{
    [SerializeField]
    private AudioClip destroyedSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DestroyObj(bool destroyedByPlayer)
    {
        // Only destroys the obj one time
        if (destroyedByPlayer)
        {
            //PlaySound();
            //TODO: PLAY ANIM 
            FindObjectOfType<BotEndGameZone>().MoveEndZone(gameObject, true);
            
        }
        Destroy(gameObject);
    }

    private void PlaySound()
    {
        audioSource.clip = destroyedSound;
        audioSource.Play();
    }
}
