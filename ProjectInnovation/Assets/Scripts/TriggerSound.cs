using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerSound : MonoBehaviour
{
    [Tooltip("Messages played on each consecutive enter in the Zone")]
    [SerializeField]
    AudioSource[] audioSouces;

    int currentSound = 0;

    [SerializeField]
    UnityEvent onEnterRoomEvent;

    public void PlayNextSound() { 
        if(audioSouces.Length <= 0)
        {
            return;
        }
        if (currentSound >= audioSouces.Length) {
            return;
        }

        if (audioSouces[currentSound].isPlaying)
        {
            return;
        }
        else {
            currentSound++;
            audioSouces[currentSound].Play();
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        onEnterRoomEvent?.Invoke();
    }
}
