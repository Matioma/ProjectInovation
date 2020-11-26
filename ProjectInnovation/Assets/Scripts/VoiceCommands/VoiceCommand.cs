using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommand : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    //[SerializeField]
    ActivateObjectQuest[] ControlledObjects;


    private void Start()
    {
        //actions.Add("can you help me", Help);
        //actions.Add("give directions", Directions);
        //actions.Add("main menu", MainMenu);
        //actions.Add("quit", Quit);
        //actions.Add("are you here", AreYouHere);
        ControlledObjects = FindObjectsOfType<ActivateObjectQuest>();

        for (int i = 0; i < ControlledObjects.Length; i++)
        {
            try
            {
                actions.Add(ControlledObjects[i].PhraseToRecongnize, ControlledObjects[i].voiceCommand);
            }
            catch (Exception stringError) {
                Debug.Log(stringError);
            }
            
        }

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();



    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speeech)
    {
        Debug.Log(speeech.text);
        actions[speeech.text].Invoke();
    }

    private void Help()
    {
        Debug.Log("Help on the way");
    }
    //private void MainMenu()
    //{
    //    Debug.Log("Main menu is open");
    //}
    //private void Directions()
    //{
    //    Debug.Log("Here are the directions");
    //}

    //private void Quit()
    //{
    //    Debug.Log("Are you sure you want to quit?");
    //}

    //private void AreYouHere()
    //{
    //    Debug.Log("I am here");
    //}
}
