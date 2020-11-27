using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]
public class AudioSequence : MonoBehaviour
{
    [SerializeField]
    bool startOnAwake=false;


    [Tooltip("0-> start, 1 -> loop, 2- end sound")]
    [SerializeField]
    List<AudioClip> audioClips;


    int audioIndex =0;

    [SerializeField]
    bool playAsSequence = false;

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
        if (startOnAwake) {
            StartSequence();
        }
    }

    public void StartSequence()
    {
        Debug.Log("Started");
        if (audioClips == null || audioClips.Count <= 0) {
            return;
        }
        sequnceStarted = true;
        onSequenceStart?.Invoke();
        GetComponent<AudioSource>().PlayOneShot(audioClips[audioIndex]);       
    }

    public void StopSequence() {
        audio.Stop();

        audio.clip = audioClips[2];
        audio.loop = false;

        audio.Play();
        Debug.Log(audio.isPlaying);
    }


    private void PlayNextAudio() {
        if (playAsSequence) {
            if (audioIndex < audioClips.Count - 1)
            {
                audioIndex++;
                audio.PlayOneShot(audioClips[audioIndex]);

                //if (audioIndex == 1)
                //{
                //    audio.clip = audioClips[audioIndex];
                //    audio.loop = true;
                //    audio.Play();
                //}
            }
            else
            {
                sequenceEnded = true;
                onSequenceEnd?.Invoke();
            }
            return;
        }


        if (audioIndex < audioClips.Count - 1)
        {
            audioIndex++;
            if (audioIndex == 1)
            {
                audio.clip = audioClips[audioIndex];
                audio.loop = true;
                audio.Play();
            }
        }
        else {
            sequenceEnded = true;
            onSequenceEnd?.Invoke();
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
