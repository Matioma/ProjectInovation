using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]
public class AudioSequence : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> audioClips;



    int audioIndex =0;
    bool sequnceStarted = false;

    bool sequenceEnded = false;
    public bool SequenceEnded
    {
        get { return sequenceEnded; }
    }

    [SerializeField]
    UnityEvent onSequenceStart;
    [SerializeField]
    UnityEvent onSequenceEnd;

    AudioSource audio;

    
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        Debug.Log(audioClips.Count);
    }

    public void StartSequence()
    {
        if (audioClips == null || audioClips.Count <= 0) {
            return;
        }
        sequnceStarted = true;
        Debug.Log(audioClips[audioIndex]);
        GetComponent<AudioSource>().PlayOneShot(audioClips[audioIndex]);       
    }

    private void PlayNextAudio() {
        if (audioIndex < audioClips.Count - 1)
        {
            audioIndex++;
            audio.PlayOneShot(audioClips[audioIndex]);
        }
        else {
            sequenceEnded = true;
        }
    }

    private void Update()
    {
        if (sequnceStarted)
        {
            if (!audio.isPlaying)
            {
                PlayNextAudio();
            }
        }
    }
}
