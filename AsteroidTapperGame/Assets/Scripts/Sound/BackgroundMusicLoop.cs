using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicLoop : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    private int currentClip = 0;

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayClip();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayClip();
        }
    }

    private AudioClip GetNextClip()
    {
        AudioClip clip = clips[currentClip];

        currentClip++;
        if (currentClip >= clips.Length)
        {
            currentClip = 0;
        }

        return clip;
    }

    private void PlayClip()
    {
        if(clips.Length > 0)
        {
            audioSource.clip = GetNextClip();
            audioSource.Play();
        }
    }
}