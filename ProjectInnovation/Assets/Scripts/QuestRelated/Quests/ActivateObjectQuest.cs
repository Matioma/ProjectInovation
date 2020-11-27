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
    GameObject user;

    bool inRange = false;
    bool madeAction = false;

    [SerializeField]
    string keyPhrase;
    public string KeyPhrase {
        get { return keyPhrase; }
    }

    public Action onPhraseHeardAction;

    [SerializeField]
    bool rangeIsImportant = false;

    [Header ("Quest specific events")]
    public UnityEvent onActivateObject;
    public UnityEvent onGetInRange;
    public UnityEvent onLeaveRange;


    private void Awake()
    {
        base.Awake();
        onPhraseHeardAction += OnPhraseHeard;
    }

    private void OnPhraseHeard() {
        if (rangeIsImportant)
        {
            if (!inRange) return;
        }

        madeAction = true;
    }



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

    public override bool CheckCondition()
    {
        if (rangeIsImportant) {
            if (!inRange) return false;
        }

        if (Input.GetKeyDown(keyAction)) {
            onActivateObject?.Invoke();
            madeAction = true;
        }
        return madeAction;
    }
}
