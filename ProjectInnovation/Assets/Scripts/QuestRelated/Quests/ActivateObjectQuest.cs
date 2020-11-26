using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActivateObjectQuest : Quest
{
    [SerializeField]
    KeyCode keyAction;



    [SerializeField]
    string phraseToRecongnize;

    public Action voiceCommand;

    private void Awake()
    {
        base.Awake();
        voiceCommand += OnQuestComplete;
    }

    public void OnQuestComplete() {
        //if (inRange)
        //{
            onActivateObject?.Invoke();
            madeAction = true;
        //}
        Debug.Log(phraseToRecongnize);
    }

    public string PhraseToRecongnize {
        get { return phraseToRecongnize; }
    }


    [SerializeField]
    GameObject user;

    bool inRange = false;
    bool madeAction = false;

    [Header ("Quest specific events")]
    public UnityEvent onActivateObject;
    public UnityEvent onGetInRange;
    public UnityEvent onLeaveRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == user)
        {
            onGetInRange?.Invoke();
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == user)
        {
            onLeaveRange?.Invoke();
            inRange = false;
        }
    }

    public void IsDone() {

        madeAction = true;
    }


    public override bool CheckCondition()
    {
        if (Input.GetKeyDown(keyAction) && inRange)
        {
            onActivateObject?.Invoke();
            madeAction = true;
        }

        return madeAction;
    }
}
