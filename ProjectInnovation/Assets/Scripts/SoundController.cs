using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    [SerializeField]
    UnityEvent onSoundEnded;


    AudioSource audioSource;
    //bool isPlaying;

    bool wasPlaying = false;
    bool audioWasPlaying = false;


    private void SetPreviousAudioState(bool value)
    {
        if (isPlaying != audioWasPlaying)
        {
            if (isPlaying == false)
            {
                onSoundEnded?.Invoke();
            }
            audioWasPlaying = isPlaying;
        }
    }


    public bool isPlaying {
        get {
            return audioSource.isPlaying;
        }
    }

    public void Play() {
        audioSource.Play();
    }



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SetPreviousAudioState(isPlaying);
    }

}
