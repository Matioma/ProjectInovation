using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPosition : MonoBehaviour
{
    [SerializeField]
    List<Vector3> positions;
    int currentSound = 0;

    private void Start()
    {
        UpdateSoundPosition();
    }

    public void UpdateSoundPosition() {
        if (currentSound >= positions.Count) {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            // Application.Quit();
            return;
        }


        Vector3 position = positions[currentSound];
        transform.position = position;
        currentSound++;
    }

}
