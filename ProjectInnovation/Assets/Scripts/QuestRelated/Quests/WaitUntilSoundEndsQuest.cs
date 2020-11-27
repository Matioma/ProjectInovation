using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilSoundEndsQuest : Quest
{
    [SerializeField]
    AudioSource audioToWait;

    void Awake()
    {
        base.Awake();
    }


    private void Start()
    {
       
    }

    public override bool CheckCondition()
    {
        return audioToWait.isPlaying;
        
    }
}
