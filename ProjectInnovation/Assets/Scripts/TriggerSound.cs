using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField]
    AudioSource[] audioSouces;

    int currentSound = 0;


    void PlayNextSound() { 
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayNextSound();
        Debug.Log("Trigger!!");
    }
}
