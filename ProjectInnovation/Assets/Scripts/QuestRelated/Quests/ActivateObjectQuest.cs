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

    public override bool CheckCondition()
    {
        if (Input.GetKeyDown(keyAction) && inRange) {
            onActivateObject?.Invoke();
            madeAction = true;
        }
        return madeAction;
    }
}
