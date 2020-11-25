using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Quest : MonoBehaviour, IQuest
{
    [SerializeField]
    string questIdentifier;


    public UnityEvent onQuestComplete;
    public UnityEvent onQuestStart;


    protected void MessageStart() {
        Debug.Log("Start quest " + questIdentifier);
    }
    protected void MessageEnd()
    {
        Debug.Log("End quest " + questIdentifier);
    }

    public void Awake()
    {
        onQuestStart.AddListener(MessageStart);
        onQuestComplete.AddListener(MessageEnd);
    }


    public virtual bool CheckCondition()
    {
        return false;
    }
}
