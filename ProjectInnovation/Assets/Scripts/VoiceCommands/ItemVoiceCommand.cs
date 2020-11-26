using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVoiceCommand : MonoBehaviour//,IVoiceCommandable
{
    [SerializeField]
    string ObjName;
    [SerializeField]
    AudioClip sound;
    AudioSource source;

    public void PlaySound()
    {
        if (source.isPlaying == false)
        {
            source.Play();
        }
    }

    public void StopSound()
    {
        if (source.isPlaying == true)
        {
            source.Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        sound = source.clip;
    }

}
