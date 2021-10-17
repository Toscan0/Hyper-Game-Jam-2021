using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip destroyedSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SelfDestroy.OnAesteroidDestroyed += PlaySound;
    }

    private void Start()
    {
        audioSource.clip = destroyedSound;

    }

    public void PlaySound(GameObject gj)
    {
        audioSource.Play();
    }

    private void OnDestroy()
    {
        SelfDestroy.OnAesteroidDestroyed -= PlaySound;
    }
}
