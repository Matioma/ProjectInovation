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
        //onQuestStart.AddListener(Message);
    }


    private void Start()
    {
       
    }


    public void Message() {
        audioToWait.Play();
    }

    public override bool CheckCondition()
    {
        return false;
    }
}
