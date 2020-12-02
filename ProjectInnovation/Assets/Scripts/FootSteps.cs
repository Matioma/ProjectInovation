using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FootSteps : MonoBehaviour
{
    AudioSource LeftStepSource;
    AudioSource RightStepSource;

    bool IsMovingWithLeftStep = true;


    AudioClip[] audioFiles;


    public void MakeStep()
    {
        int audioFileIndex = Random.Range(0, audioFiles.Length);

        if (IsMovingWithLeftStep)
        {
            LeftStepSource.PlayOneShot(audioFiles[audioFileIndex]);
        }
        else {
            RightStepSource.PlayOneShot(audioFiles[audioFileIndex]);
        }

        IsMovingWithLeftStep = !IsMovingWithLeftStep;
    }



}
